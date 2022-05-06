using NUnit.Framework;
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
            this._list = new List<Pair<string, int>>()
            {
                new Pair<string, int>("First", 90),
                new Pair<string, int>("Second", 75),
                new Pair<string, int>("Third", 60),
                new Pair<string, int>("Fourth", 45),
                new Pair<string, int>("Fifth", 30)
            };
        }

        [Test]
        public void TestLeaderboard()
        {
            CollectionAssert.AreEqual(this._leaderboard.Ranking, this._list);
            
            Assert.AreEqual(1, this._leaderboard.GetRank("First", 90));
            Assert.AreEqual(2, this._leaderboard.GetRank("Second", 75));
            Assert.AreEqual(3, this._leaderboard.GetRank("Third", 60));
            Assert.AreEqual(4, this._leaderboard.GetRank("Fourth", 45));
            Assert.AreEqual(5, this._leaderboard.GetRank("Fifth", 30));
        }

        [Test]
        public void TestPair()
        {
            var pair = new Pair<string, int>("Lol", 5);
            Assert.AreEqual("Lol", pair.First);
            Assert.AreEqual(5, pair.Second);

            var pair2 = new Pair<string, int>("Lol", 5);
            Assert.IsTrue(pair.Equals(pair2));
            Assert.AreEqual("Pair [e1=Lol, e2=5]", pair.ToString());
        }

        [Test]
        public void TestRankItem()
        {
            var rankItem = new RankItem(7, "Hello World", 420);
            Assert.AreEqual(7, rankItem.Rank);
            Assert.AreEqual("Hello World", rankItem.Name);
            Assert.AreEqual(420, rankItem.Score);
        }

        [Test]
        public void TestScoreCalc()
        {
            var scoreCalc = new ScoreCalc();
            Assert.IsFalse(scoreCalc.CalcStatus);
            Assert.AreEqual(0, scoreCalc.Score);

            scoreCalc.CalcStatus = true;
            Assert.IsTrue(scoreCalc.CalcStatus);
            Assert.AreEqual(0, scoreCalc.Score);

            scoreCalc.CalculateScore(0.06666667);
            Assert.AreEqual(1, scoreCalc.Score);

            scoreCalc.CalculateScore(0.06666667);
            Assert.AreEqual(2, scoreCalc.Score);

            scoreCalc.IncScore(8);
            Assert.AreEqual(10, scoreCalc.Score);

            Assert.AreEqual(1, scoreCalc.Multiplier);
            scoreCalc.SetMultiplier();
            Assert.AreEqual(2, scoreCalc.Multiplier);
            scoreCalc.CalculateScore(0.06666667);
            Assert.AreEqual(12, scoreCalc.Score);
            scoreCalc.IncScore(2);
            Assert.AreEqual(16, scoreCalc.Score);

            scoreCalc.SetMultiplier(3);
            Assert.AreEqual(3, scoreCalc.Multiplier);
            scoreCalc.CalculateScore(0.06666667);
            Assert.AreEqual(19, scoreCalc.Score);
            scoreCalc.IncScore(2);
            Assert.AreEqual(25, scoreCalc.Score);

            scoreCalc.ResetMultiplier();
            Assert.AreEqual(1, scoreCalc.Multiplier);
        }

        [Test]
        public void TestScoreManager()
        {
            //editMode="TRUE"
            var scoreManager = new ScoreManager("Sixth", 15, this._leaderboard);
            this._list.Add(new Pair<string, int>("Sixth", 15));
            Assert.AreEqual(this._list, scoreManager.GetRanking());
            Assert.IsFalse(scoreManager.ReadOnly);
            Assert.AreEqual("Sixth", scoreManager.PlayerName);
            Assert.AreEqual(15, scoreManager.Score);
            Assert.AreEqual(6, scoreManager.GetRank());
        }

        [Test]
        public void TestScoreManagerReadOnly()
        {
            //editMode="FALSE"
            var scoreManager = new ScoreManager(this._leaderboard);    //read-only
            Assert.AreEqual(this._list, scoreManager.GetRanking());
            Assert.IsTrue(scoreManager.ReadOnly);
        }
    }
}
