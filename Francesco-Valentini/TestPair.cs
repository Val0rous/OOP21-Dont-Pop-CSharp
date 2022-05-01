using NUnit.Framework;
using System;

namespace Francesco_Valentini
{
    public class TestPair
    {
        [Test]
        public void TestPoint2D()
        {
            var pair = new Pair<String, Int32>("Lol", 5);
            Assert.AreEqual(pair.Get1(), "Lol");
            Assert.AreEqual(pair.Get2(), 5);
            Assert.IsTrue(pair.Equals(pair));
            Assert.AreEqual(pair.ToString(), "Pair [e1=Lol, e2=5]");

            Console.WriteLine("TestPair completed successfully");
        }
    }
}