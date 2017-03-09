using BotFactory.Common.Tools;
using System.Threading.Tasks;

namespace BotFactory.Interface
{
    public interface IWorkingUnit : IBaseUnit
    {
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }
        bool IsWorking { get; set; }
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
      
    }
}
