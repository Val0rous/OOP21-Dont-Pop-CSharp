using System;
using MicheleRavaioli;

namespace MarioBiavati
{
    class PlayerObj
    {
        public Point2D position;
        Point2D movement;
        double speed = 0.075;

        public PlayerObj(Point2D pos, double s)
        {
            position = pos;
            speed = s;
        }

        public void Update(Point2D mousePosition)
        {
            movement = mousePosition - position;
            if (movement.Magnitude <= speed) this.position += movement;
            else this.position += (movement / movement.Magnitude) * speed;
        }
    }
}