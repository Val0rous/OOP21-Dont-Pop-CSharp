using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Francesco_Valentini
{
    public class Test
    {
        Leaderboard leaderboard = new Leaderboard();
        List<Pair<string, int>> list = new List<Pair<string, int>>();

        [Test]
        public void TestLeaderboard()
        {
            this.leaderboard.AddToRanking("Fifth", 30);
            this.leaderboard.AddToRanking("Third", 60);
            this.leaderboard.AddToRanking("Second", 75);
            this.leaderboard.AddToRanking("Fourth", 45);
            this.leaderboard.AddToRanking("First", 90);
            
            this.list.Add(new Pair<string, int>("First", 90));
            this.list.Add(new Pair<string, int>("Second", 75));
            this.list.Add(new Pair<string, int>("Third", 60));
            this.list.Add(new Pair<string, int>("Fourth", 45));
            this.list.Add(new Pair<string, int>("Fifth", 30));

            Assert.AreEqual(leaderboard.Ranking, list);

            Assert.AreEqual(leaderboard.GetRank("First", 90), 1);
            Assert.AreEqual(leaderboard.GetRank("Second", 75), 2);
            Assert.AreEqual(leaderboard.GetRank("Third", 60), 3);
            Assert.AreEqual(leaderboard.GetRank("Fourth", 45), 4);
            Assert.AreEqual(leaderboard.GetRank("Fifth", 30), 5);
        }

        [Test]
        public void TestPair()
        {
            var pair = new Pair<String, Int32>("Lol", 5);
            Assert.AreEqual(pair.e1, "Lol");
            Assert.AreEqual(pair.e2, 5);
            Assert.IsTrue(pair.Equals(pair));
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
            var scoreManager = new ScoreManager("Sixth", 15, this.leaderboard);
            this.list.Add(new Pair<string, int>("Sixth", 15));
            Assert.AreEqual(scoreManager.GetRanking(), this.list);
            Assert.IsFalse(scoreManager.ReadOnly);
            Assert.AreEqual(scoreManager.PlayerName, "Sixth");
            Assert.AreEqual(scoreManager.Score, 15);
            Assert.AreEqual(scoreManager.GetRank(), 6);

            //editMode="FALSE"
            var scoreManagerRO = new ScoreManager(this.leaderboard);    //read-only
            Assert.AreEqual(scoreManagerRO.GetRanking(), this.list);
            Assert.IsTrue(scoreManagerRO.ReadOnly);
        }
    }
}