namespace BotFactory.Common.Tools

{
    public class Coordinates
    {
        #region ATTR
        public double X { get; set; }
        public double Y { get; set; }
        #endregion
        public Coordinates() { }
        public Coordinates(double x1, double y1)
        {
            X = x1;
            Y = y1;
        }
        public bool Equals(double x, double y)
        {
            if (x == X && y == Y)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
