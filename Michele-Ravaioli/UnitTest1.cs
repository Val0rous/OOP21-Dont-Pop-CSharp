using NUnit.Framework;

namespace Michele_Ravaioli
{
    public class UnitTest1
    {
        [Test]
        public void TestPoint2D()
        {
            var a = new Point2D(3, 3);
            var b = Point2D.Of(2, 2);
            double f = 10;

            Assert.IsFalse(a == b);
            Assert.IsFalse(a * f == a);
            Assert.IsTrue(b * f != b);

            var c = a + b;

            Assert.IsTrue(c.X == 5);

            a.Y += 1;

            Assert.IsTrue(a.Magnitude == 5);
        }
    }
}
