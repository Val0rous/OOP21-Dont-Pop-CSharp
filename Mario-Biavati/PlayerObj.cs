using System;
using MicheleRavaioli;

namespace MarioBiavati
{
    class PlayerObj
    {
        bool isDead = false;
        public Point2D position;
        Point2D movement;
        double speed = 0.075;
        double radius = 1;

        public PlayerObj(Point2D pos, double s)
        {
            position = pos;
            speed = s;
        }

        public bool IsDead()
        {
            return isDead;
        }



        public void Update(Point2D mousePosition, LineCollider collider)
        {
            movement = mousePosition - position;
            if (movement.Magnitude <= speed) this.position += movement;
            else this.position += (movement / movement.Magnitude) * speed;
            // Collision check
            if (collider.getDistance(position) <= radius)
            {
                isDead = true;
            }
        }
    }
}