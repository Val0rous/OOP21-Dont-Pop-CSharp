using NUnit.Framework;
using System;
using MicheleRavaioli;

namespace ManuelTartagni
{
    [TestFixture]
    public class TestWhereToSpawn
    {
        private RandomInt randomInt;
        private WhereToSpawn wheretospawn;
        private Point2D point2d;

        public Point2D Point2d;

        [SetUp]
        public void Init()
        {
            this.randomInt = new RandomInt();
            this.wheretospawn = new WhereToSpawn();
            this.Point2d = new Point2D(0.2, -0.2);
        }


        [Test]
        public void TestRandomInt()
        {   //1,1
            this.randomInt.GetRandomInt(1, 1);
            Assert.AreEqual(this.randomInt, 1);

            bool check;
           //1,4
            this.randomInt.GetRandomInt(1, 4);
            int number = randomInt.RandomInt2;
            check = number <= 4 || number >= 1 ? true : false;
            Assert.IsTrue(check);
            //3-4
            this.randomInt.GetRandomInt(3, 4);
             number = randomInt.RandomInt2;
            check = number <= 4 || number >= 3 ? true : false;
            Assert.IsTrue(check);
            //4,4
            this.randomInt.GetRandomInt(4, 4);
            Assert.AreEqual(this.randomInt, 4);
        }
       
        [Test]
        public void TestRandomSide()
         {

               int side= this.wheretospawn.GetRandomSide();
               bool check;
               if (side <= 4 || side >= 1)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                    Assert.IsTrue(check);
        }
               
        [Test]
        public void TestThornballRandomSide()
        {
            Boolean check2;
            if (this.wheretospawn.GetThornballRandomSide() == 1 || this.wheretospawn.GetThornballRandomSide() == 3)
            {
                check2 = true;
            }
            else
            {
                check2 = false;
            }
            Assert.IsTrue(check2);
        }

        [Test]
        public void TestThornballSpawnPoint()
        {
            Assert.IsTrue(this.wheretospawn.GetThornballSpawnPoint(1) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetThornballSpawnPoint(2) == this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetThornballSpawnPoint(3) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetThornballSpawnPoint(4) == this.Point2d);
            Assert.AreEqual(this.wheretospawn.GetThornballSpawnPoint(5), this.Point2d);
        }


        [Test]
        public void TestEnemySpawnPoint()
        {
            Assert.IsTrue(this.wheretospawn.GetEnemySpawnPoint(1) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetEnemySpawnPoint(2) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetEnemySpawnPoint(3) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetEnemySpawnPoint(4) != this.Point2d);
            Assert.AreEqual(this.wheretospawn.GetEnemySpawnPoint(5), this.Point2d);
        }
      

    }
   
}
