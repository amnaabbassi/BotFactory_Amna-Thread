using BotFactory.Common.Tools;
using BotFactory.Interface;
using System;

namespace BotFactory.Factories
{
    public class FactoryQueueElement  : IFactoryQueueElement
    {
        #region ATTR

        public string Name { get; set; }
        public Type Model { get; set; }
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        public FactoryQueueElement(Type model,string name, Coordinates pks,Coordinates wks)
        {
            Model = model;
            Name = name;
            ParkingPos = pks;
            WorkingPos = wks;
        }

       
        #endregion



    }
}
