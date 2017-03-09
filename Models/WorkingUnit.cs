using BotFactory.Common.Tools;
using BotFactory.Interface;
using System;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit, ITestingUnit
    {
        #region ATTR
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        private bool isWorking;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }

            set
            {
                isWorking = value;

            }
        }

        #endregion
        public WorkingUnit(double vitesse, double buildTime)
          : base(vitesse, buildTime)
        {

        }
        public WorkingUnit(String nom, Type model, double speed = 5, double buildtime = 5)
        {
            ParkingPos = new Coordinates();
            WorkingPos = new Coordinates();
        }


        public async Task<bool> WorkBegins()
        {
            await Move(CurrentPos, WorkingPos);
            OnStatusChanged(this, new StatusChangedEventArgs() { NewStatus = ("hallelujah,I'm at work......") });
            IsWorking = true;
            CurrentPos.X = WorkingPos.X;
            CurrentPos.Y = WorkingPos.Y;
            return IsWorking;
        }

        public async Task<bool> WorkEnds()
        {
            await Task.Delay(1000);
            CurrentPos.X = 0;
            CurrentPos.Y = 0;
            OnStatusChanged(this, new StatusChangedEventArgs() { NewStatus = ("Finally holiday! holiday!  :) ......") });
            IsWorking = false;
            return IsWorking;
        }
    }
}
