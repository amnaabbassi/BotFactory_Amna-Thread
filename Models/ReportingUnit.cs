using BotFactory.Interface;
using System;
namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit, IReportingUnit
    {
        public string NewStatus { get; set; }

        public event EventHandler UnitStatusChanged;

        public ReportingUnit(double buildTime)
         : base(buildTime)
        {

        }
        public ReportingUnit()
        {

        }

        public void OnStatusChanged(object sender, IStatusChangedEventArgs args)
        {
            UnitStatusChanged?.Invoke(sender, (StatusChangedEventArgs)args);
        }
    }
}
