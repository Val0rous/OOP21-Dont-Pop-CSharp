using System;
using MicheleRavaioli;

namespace MarioBiavati
{
    public class LineEnemy
    {
        public LineCollider collider;
        public Point2D p1, p2;

        public LineEnemy(Point2D start, Point2D end) 
        {
            p1 = start;
            p2 = end;
            collider = new LineCollider(p1, p2, 0.02);
        }

    }
}
