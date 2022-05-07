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
            var mousePos1 = new Point2D(0, 0);
            var mousePos2 = new Point2D(0.5, 0.5);
            var mousePos3 = new Point2D(10.5, 10.5);

            player.Update(mousePos1);

            Assert.IsTrue(player.position == mousePos1);

            player.Update(mousePos2);

            Assert.IsTrue(player.position == mousePos2);

            player.Update(mousePos3);

            Assert.IsFalse(player.position == mousePos3);
            Assert.IsTrue(player.position == mousePos2 + ((mousePos3 / mousePos3.Magnitude) * speed));
        }
    }
}
