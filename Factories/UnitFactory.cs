using BotFactory.Common.Tools;
using BotFactory.Interface;
using BotFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BotFactory.Factories
{
    public class UnitFactory : IUnitFactory
    {
        #region ATTR
        public int QueueCapacity { get; set; }
        public int StorageCapacity { get; set; }
        public int QueueFreeSlots { get; set; }
        public int StorageFreeSlots { get; set; }
        public Coordinates WorkingPos;
        public Coordinates ParkingPos;
        public bool factoryIsUpAndRunning { get; set; }
        private TimeSpan _queueTime = TimeSpan.FromSeconds(0);
        public event EventHandler FactoryStatus;
        private object obj = new object();
        Thread MyThread;

        private List<IFactoryQueueElement> _queue;
        private List<ITestingUnit> _storage;
        public List<IFactoryQueueElement> Queue
        {
            get
            {
                return _queue.ToList();
            }
            set
            {
                _queue = value;
            }


        }

        public List<ITestingUnit> Storage
        {
            get
            {
                return _storage.ToList();
            }

            set
            {
                _storage = value;
            }
        }

        public TimeSpan QueueTime
        {
            get
            {
                return _queueTime;
            }

            set
            {
                _queueTime = value;
            }
        }

        #endregion

        #region Method 
        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingpos, Coordinates workingpos)
        {
            QueueFreeSlots = QueueCapacity - _queue.Count;          // QFS = 5  - x
            StorageFreeSlots = StorageCapacity - _storage.Count;    // SFS = 10 - x

            if ((QueueFreeSlots > 0) && (StorageFreeSlots > 0) && (StorageFreeSlots - _queue.Count > 0))
            {
                var fqe = new FactoryQueueElement(model, name, parkingpos, workingpos);
                _queue.Add(fqe);
                if (!factoryIsUpAndRunning)
                {
                    if (Monitor.TryEnter(obj))
                    {
                        Monitor.Pulse(obj);
                        Monitor.Exit(obj);
                    }
                }
                return true;
            }

            return false;
        }

        public void Construire()
        {
            Monitor.Enter(obj);
            lock (obj)
            {
                // Create an instance of the ITestingUnit type using 
                // Activator.CreateInstance.
                while (!factoryIsUpAndRunning)
                {
                    if (factoryIsUpAndRunning || (Queue.Count == 0))
                        OnStatusChanged(this, new StatusChangedEventArgs() { NewStatus = "hello................." });
                    else
                    {

                        factoryIsUpAndRunning = true;

                        IFactoryQueueElement factoryelement = _queue[0];
                        ITestingUnit testUnit = (ITestingUnit)Activator.CreateInstance(factoryelement.Model);

                        Thread.Sleep(TimeSpan.FromSeconds(testUnit.BuildTime));

                        testUnit.ParkingPos = factoryelement.ParkingPos;
                        testUnit.WorkingPos = factoryelement.WorkingPos;
                        testUnit.CurrentPos = factoryelement.ParkingPos;
                        testUnit.Name = factoryelement.Name;
                        testUnit.Model = factoryelement.Model.Name;

                        OnStatusChanged(testUnit, new StatusChangedEventArgs() { NewStatus = "I'm building my bot.." });
                        QueueTime += TimeSpan.FromSeconds(testUnit.BuildTime);


                        OnStatusChanged(testUnit, new StatusChangedEventArgs() { NewStatus = "Add to Storage.." });
                        _storage.Add(testUnit);
                        _queue.Remove(factoryelement);

                        factoryIsUpAndRunning = false;
                    }
                }

            }
        }

        public UnitFactory(int q, int s)
        {
            QueueCapacity = q;
            StorageCapacity = s;
            Queue = new List<IFactoryQueueElement>();
            Storage = new List<ITestingUnit>();
            factoryIsUpAndRunning = false;
            MyThread = new Thread(new ThreadStart(Construire));
            MyThread.Start();
            MyThread.IsBackground = false;

        }
        private void OnStatusChanged(object sender, StatusChangedEventArgs statusChangedEventArgs)
        {
            FactoryStatus?.Invoke(sender, statusChangedEventArgs);
        }
        #endregion
    }
}
