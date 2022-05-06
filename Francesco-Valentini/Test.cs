using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Francesco_Valentini
{
    [TestFixture]
    public class Test
    {
        private Leaderboard _leaderboard;
        private List<Pair<string, int>> _list;
        
        [SetUp]
        public void InitLeaderboard()
        {
            this._leaderboard = new Leaderboard();
            this._leaderboard.AddToRanking("Fifth", 30);
            this._leaderboard.AddToRanking("Third", 60);
            this._leaderboard.AddToRanking("Second", 75);
            this._leaderboard.AddToRanking("Fourth", 45);
            this._leaderboard.AddToRanking("First", 90);
        }
        
        [SetUp]
        public void InitList()
        {
            this._list = new List<Pair<string, int>>();
            this._list.Add(new Pair<string, int>("First", 90));
            this._list.Add(new Pair<string, int>("Second", 75));
            this._list.Add(new Pair<string, int>("Third", 60));
            this._list.Add(new Pair<string, int>("Fourth", 45));
            this._list.Add(new Pair<string, int>("Fifth", 30));
        }

        [Test]
        public void TestLeaderboard()
        {
            CollectionAssert.AreEqual(this._leaderboard.Ranking, this._list);
            
            Assert.AreEqual(this._leaderboard.GetRank("First", 90), 1);
            Assert.AreEqual(this._leaderboard.GetRank("Second", 75), 2);
            Assert.AreEqual(this._leaderboard.GetRank("Third", 60), 3);
            Assert.AreEqual(this._leaderboard.GetRank("Fourth", 45), 4);
            Assert.AreEqual(this._leaderboard.GetRank("Fifth", 30), 5);
        }

        [Test]
        public void TestPair()
        {
            var pair = new Pair<string, int>("Lol", 5);
            Assert.AreEqual(pair.e1, "Lol");
            Assert.AreEqual(pair.e2, 5);

            var pair2 = new Pair<string, int>("Lol", 5);
            Assert.IsTrue(pair.Equals(pair2));
            Assert.AreEqual(pair.ToString(), "Pair [e1=Lol, e2=5]");
        }

        [Test]
        public void TestRankItem()
        {
            var rankItem = new RankItem(7, "Hello World", 420);
            Assert.AreEqual(rankItem.Rank, 7);
            Assert.AreEqual(rankItem.Name, "Hello World");
            Assert.AreEqual(rankItem.Score, 420);
        }

        [Test]
        public void TestScoreCalc()
        {
            var scoreCalc = new ScoreCalc();
            Assert.IsFalse(scoreCalc.CalcStatus);
            Assert.AreEqual(scoreCalc.Score, 0);

            scoreCalc.CalcStatus = true;
            Assert.IsTrue(scoreCalc.CalcStatus);
            Assert.AreEqual(scoreCalc.Score, 0);

            scoreCalc.CalculateScore(0.06666667);
            Assert.AreEqual(scoreCalc.Score, 1);

            scoreCalc.CalculateScore(0.06666667);
            Assert.AreEqual(scoreCalc.Score, 2);

            scoreCalc.IncScore(8);
            Assert.AreEqual(scoreCalc.Score, 10);

            Assert.AreEqual(scoreCalc.Multiplier, 1);
            scoreCalc.SetMultiplier();
            Assert.AreEqual(scoreCalc.Multiplier, 2);
            scoreCalc.CalculateScore(0.06666667);
            Assert.AreEqual(scoreCalc.Score, 12);
            scoreCalc.IncScore(2);
            Assert.AreEqual(scoreCalc.Score, 16);

            scoreCalc.SetMultiplier(3);
            Assert.AreEqual(scoreCalc.Multiplier, 3);
            scoreCalc.CalculateScore(0.06666667);
            Assert.AreEqual(scoreCalc.Score, 19);
            scoreCalc.IncScore(2);
            Assert.AreEqual(scoreCalc.Score, 25);

            scoreCalc.ResetMultiplier();
            Assert.AreEqual(scoreCalc.Multiplier, 1);
        }

        [Test]
        public void TestScoreManager()
        {
            //editMode="TRUE"
            var scoreManager = new ScoreManager("Sixth", 15, this._leaderboard);
            this._list.Add(new Pair<string, int>("Sixth", 15));
            Assert.AreEqual(scoreManager.GetRanking(), this._list);
            Assert.IsFalse(scoreManager.ReadOnly);
            Assert.AreEqual(scoreManager.PlayerName, "Sixth");
            Assert.AreEqual(scoreManager.Score, 15);
            Assert.AreEqual(scoreManager.GetRank(), 6);
        }

        [Test]
        public void TestScoreManagerReadOnly()
        {
            //editMode="FALSE"
            var scoreManager = new ScoreManager(this._leaderboard);    //read-only
            Assert.AreEqual(scoreManager.GetRanking(), this._list);
            Assert.IsTrue(scoreManager.ReadOnly);
        }
    }
}
