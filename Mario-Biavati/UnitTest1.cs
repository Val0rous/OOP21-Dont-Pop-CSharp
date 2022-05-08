using NUnit.Framework;
using MicheleRavaioli;

namespace MarioBiavati
{
    public class UnitTest1
    {
        [Test]
        public void TestPlayer()
        {
            var speed = 1;
            var player = new PlayerObj(new Point2D(0, 0), speed);
            LineEnemy lineEnemy;
            // Simulates mouse movement
            var mousePos1 = new Point2D(0, 0);
            var mousePos2 = new Point2D(0.5, 0.5);
            var mousePos3 = new Point2D(10.5, 10.5);

            lineEnemy = new LineEnemy(Point2D.Of(3, -20), Point2D.Of(3, 20));

            // Mouse position is on player, no movement
            player.Update(mousePos1, lineEnemy.collider);

            Assert.IsTrue(player.position == mousePos1);

            // Mouse position is closer than max movement, snaps to mouse
            player.Update(mousePos2, lineEnemy.collider);

            Assert.IsTrue(player.position == mousePos2);

            // Moves towards mouse position, no snapping because point is far away
            player.Update(mousePos3, lineEnemy.collider);

            Assert.IsFalse(player.position == mousePos3);
            Assert.IsTrue(player.position == mousePos2 + (mousePos3 / mousePos3.Magnitude * speed));

            // Moves towards enemy, doesn't die
            player.Update(mousePos3, lineEnemy.collider);

            Assert.IsFalse(player.IsDead());

            // Hits enemy, dies
            player.Update(mousePos3, lineEnemy.collider);

            Assert.IsTrue(player.IsDead());
        }
    }
}
