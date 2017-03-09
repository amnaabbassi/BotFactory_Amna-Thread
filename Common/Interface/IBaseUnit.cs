using BotFactory.Common.Tools;
using System.Threading.Tasks;

namespace BotFactory.Interface
{
    public interface IBaseUnit : IReportingUnit
    {
        double vitesse { get; set; }
        string Name { get; set; }
        Coordinates CurrentPos { get; set; }
        Task<double> Move(Coordinates begin, Coordinates end);
    }
}
