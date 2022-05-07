using System;
using System.Collections.Generic;
using System.Text;

namespace MarioBiavati
{
    /**
     * Represents a point or vector in a 2-dimensional space
     */
    public struct Point2D
    {
        /*X component of the vector*/
        public double X { get; set; }

        /*Y component of the vector*/
        public double Y { get; set; }

        /*The magnitude of the vector (readonly)*/
        public double Magnitude { get => Math.Sqrt(this.X * this.X + this.Y * this.Y); }

        /* Creates a new point of coordinates (x, y) */
        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() => $"({X}, {Y})";

        public override int GetHashCode() => base.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is Point2D)
            {
                Point2D p = (Point2D)obj;
                return p.X.Equals(this.X) && p.Y.Equals(this.Y);
            }
            return false;
        }
        /*Return this vector with magnitude 1*/
        public Point2D Normalized() => this / this.Magnitude;

        /*vector addition*/
        public static Point2D operator +(Point2D a, Point2D b) => new Point2D(a.X + b.X, a.Y + b.Y);

        /*vector subtraction*/
        public static Point2D operator -(Point2D a, Point2D b) => new Point2D(a.X - b.X, a.Y - b.Y);

        /*opposite vector*/
        public static Point2D operator -(Point2D a) => new Point2D(-a.X, -a.Y);

        /*scalar multiplication*/
        public static Point2D operator *(Point2D a, double f) => new Point2D(a.X * f, a.Y * f);
        public static Point2D operator *(double f, Point2D a) => new Point2D(a.X * f, a.Y * f);

        public static Point2D operator /(Point2D a, double f) => new Point2D(a.X / f, a.Y / f);

        /*Equals method with == operator*/
        public static bool operator ==(Point2D a, Point2D b) => a.Equals(b);
        public static bool operator !=(Point2D a, Point2D b) => !(a == b);

        /*Returns a Point2D of x, y coordinates*/
        public static Point2D Of(double x, double y) => new Point2D(x, y);

        /*Return the distance between a and b*/
        public static double Distance(Point2D a, Point2D b) => (b - a).Magnitude;
    }
}
