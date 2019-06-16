using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FiguresLib
{
    abstract public class Figure
    {
        public string Label { get; set; }

        public System.Drawing.Color Color { get; set; }

        private static int counter = 0;
        public Figure()
        {
            counter++;
            this.Color = Color.Black;
            Label = $"{GetType().Name} #{counter}";
        }

        abstract public void Draw();
        public override string ToString() => $"Figure: {Label}";

        public const int FRACTIONAL_DIGITS = 4;


    }

    public class Point : Figure, IEquatable<Point>
    {
        // fields
        public readonly double X, Y; //immutability

        // constructor
        public Point(double x = 0, double y = 0)
        {
            X = Math.Round(x, Figure.FRACTIONAL_DIGITS);
            Y = Math.Round(y, Figure.FRACTIONAL_DIGITS);
            Color = Color.Blue;
        }

        public override void Draw()
        {
            Console.WriteLine("drawing: " + $"Point({X}, {Y}), {Color}");
        }

        public override string ToString() => $"Point({X},{Y})";

        #region implementation of IEquatable<Point>
        public bool Equals(Point other) => (other is null) ? false : (this.X == other.X && this.Y == other.Y);
        public override bool Equals(Object obj)
        {
            if (!this.GetType().Equals(obj.GetType())) return false;

            return this.Equals((Point)obj);
        }

        public override int GetHashCode() => unchecked(((int)X << 2) ^ (int)Y);

        static public bool operator ==(Point p1, Point p2)
        {
            if (p1 is null && p2 is null) return true;
            if (p1 is null && !(p2 is null)) return false;

            //p1 != null
            return p1.Equals(p2);
        }
        static public bool operator !=(Point p1, Point p2) => !(p1 == p2);
        #endregion
    }

}
