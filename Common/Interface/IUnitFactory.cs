
using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;

namespace BotFactory.Interface
{
    public  interface IUnitFactory 
    {
        int QueueCapacity { get; set; }    
        int StorageCapacity { get; set; }
        int QueueFreeSlots { get; set; }
        int StorageFreeSlots { get; set; }
        List<IFactoryQueueElement> Queue { get; set; }
        List<ITestingUnit> Storage { get; set; }
        TimeSpan QueueTime { get; set; }
        event EventHandler FactoryStatus;

        bool AddWorkableUnitToQueue(Type model, string name, Coordinates begin, Coordinates end );
        
    }
}
