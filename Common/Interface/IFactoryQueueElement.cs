using BotFactory.Common.Tools;
using System;

namespace BotFactory.Interface
{
    public interface IFactoryQueueElement
    {
        Type Model { get; set; }
        string Name { get; set; }
        Coordinates WorkingPos { get; set; }
        Coordinates ParkingPos { get; set; }
    }
}
