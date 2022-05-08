using System;
using MicheleRavaioli;

namespace MarioBiavati
{
    public class LineCollider
    {
        public Point2D p1, p2;
        public double thickness = 0.02;

        public LineCollider(Point2D start, Point2D end, double t)
        {
            p1 = start;
            p2 = end;
            thickness = t;
        }

        public double getDistance(Point2D point)
        {
            return (Math.Abs((p2.X-p1.X)*(p1.Y-point.Y)-(p1.X-point.X)*(p2.Y-p1.Y))/Math.Sqrt(Math.Pow(p2.X-p1.X, 2)+ Math.Pow(p2.Y - p1.Y, 2)))-thickness;
        }
    }
}
