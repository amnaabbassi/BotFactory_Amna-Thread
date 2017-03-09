using System;


namespace BotFactory.Common.Tools
{
    public class Vector
    {
        #region ATTR
        public double X { get; set; }
        public double Y { get; set; }
        #endregion
        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            Vector v = new Vector();
            v.X = end.X - begin.X;
            v.Y = end.Y - begin.Y;
            return v;
        }
        public double Length(Vector v)
        {
            return Math.Sqrt(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2));
        }
    }
}
