using NUnit.Framework;
using System;

namespace Manuel_Tartagni
{
    [TestFixture]
    public class TestWhereToSpawn
    {
        public RandomInt randomInt;
        public WhereToSpawn wheretospawn;
        public Point2D point2d;

        public Point2D Point2d { get => point2d; set => point2d = value; }

        [SetUp]
        public void Init()
        {
            this.randomInt = new RandomInt();
            this.wheretospawn = new WhereToSpawn();
            this.Point2d = new Point2D(0.2, -0.2);
        }


        [Test]
        public void TestRandomInt()
        {
            this.randomInt.GetRandomInt(1, 1);
            Assert.AreEqual(this.randomInt, 1);

            this.randomInt.GetRandomInt(1, 4);
            Boolean check;
            int number = randomInt.RandomInt2;
            check = number <= 4 || number >= 1 ? true : false;
            Assert.IsTrue(check);
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
            //passare side a getThornballSpawnPoint

            Assert.IsTrue(this.wheretospawn.GetThornballSpawnPoint(1) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetThornballSpawnPoint(2) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetThornballSpawnPoint(3) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetThornballSpawnPoint(4) != this.Point2d);
            Assert.AreEqual(this.wheretospawn.GetThornballSpawnPoint(5), this.Point2d);
        }


        [Test]
        public void TestEnemySpawnPoint()
        {
            //passare side a getThornballSpawnPoinT

            Assert.IsTrue(this.wheretospawn.GetEnemySpawnPoint(1) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetEnemySpawnPoint(2) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetEnemySpawnPoint(3) != this.Point2d);
            Assert.IsTrue(this.wheretospawn.GetEnemySpawnPoint(4) != this.Point2d);
            Assert.AreEqual(this.wheretospawn.GetEnemySpawnPoint(5), this.Point2d);
        }
      

    }
   
}
