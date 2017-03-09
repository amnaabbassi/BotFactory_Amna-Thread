

using BotFactory.Interface;

namespace BotFactory.Models
{
    public abstract class BuildableUnit : IBuildableUnit
    {
        #region
        public string Model { get; set; }
        public double BuildTime { get; set; }
        #endregion

        #region BuildableUnit
        public BuildableUnit()
        {
            BuildTime = 5;
        }
        public BuildableUnit(string model, double _buildtime = 5)
        {
            Model = model;
            BuildTime = _buildtime;
        }
        public BuildableUnit(double _buildtime = 5)
        {

            BuildTime = _buildtime;
        }
        #endregion
    }
}
