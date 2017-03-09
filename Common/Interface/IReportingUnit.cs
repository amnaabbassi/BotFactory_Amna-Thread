using System;

namespace BotFactory.Interface
{
    public  interface IReportingUnit : IBuildableUnit
    {
        event EventHandler UnitStatusChanged;
        void OnStatusChanged(object sender ,IStatusChangedEventArgs e);
    }
}
