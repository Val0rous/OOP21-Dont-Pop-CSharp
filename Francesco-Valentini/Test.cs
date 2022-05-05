using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Francesco_Valentini
{
    public class Test
    {
        private Leaderboard InitLeaderboard()
        {
            var leaderboard = new Leaderboard();
            leaderboard.AddToRanking("Fifth", 30);
            leaderboard.AddToRanking("Third", 60);
            leaderboard.AddToRanking("Second", 75);
            leaderboard.AddToRanking("Fourth", 45);
            leaderboard.AddToRanking("First", 90);

            return leaderboard;
        }
        
        private List<Pair<string, int>> InitList()
        {
            var list = new List<Pair<string, int>>();
            list.Add(new Pair<string, int>("First", 90));
            list.Add(new Pair<string, int>("Second", 75));
            list.Add(new Pair<string, int>("Third", 60));
            list.Add(new Pair<string, int>("Fourth", 45));
            list.Add(new Pair<string, int>("Fifth", 30));

            return list;
        }

        [Test]
        public void TestLeaderboard()
        {
            var leaderboard = InitLeaderboard();
            var list = InitList();
            CollectionAssert.AreEqual(leaderboard.Ranking, list);
            
            Assert.AreEqual(leaderboard.GetRank("First", 90), 1);
            Assert.AreEqual(leaderboard.GetRank("Second", 75), 2);
            Assert.AreEqual(leaderboard.GetRank("Third", 60), 3);
            Assert.AreEqual(leaderboard.GetRank("Fourth", 45), 4);
            Assert.AreEqual(leaderboard.GetRank("Fifth", 30), 5);
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
            var leaderboard = InitLeaderboard();
            var list = InitList();
            
            //editMode="TRUE"
            var scoreManager = new ScoreManager("Sixth", 15, leaderboard);
            list.Add(new Pair<string, int>("Sixth", 15));
            Assert.AreEqual(scoreManager.GetRanking(), list);
            Assert.IsFalse(scoreManager.ReadOnly);
            Assert.AreEqual(scoreManager.PlayerName, "Sixth");
            Assert.AreEqual(scoreManager.Score, 15);
            Assert.AreEqual(scoreManager.GetRank(), 6);
        }

        [Test]
        public void TestScoreManagerReadOnly()
        {
            var leaderboard = InitLeaderboard();
            var list = InitList();
            
            //editMode="FALSE"
            var scoreManager = new ScoreManager(leaderboard);    //read-only
            Assert.AreEqual(scoreManager.GetRanking(), list);
            Assert.IsTrue(scoreManager.ReadOnly);
        }
    }
}