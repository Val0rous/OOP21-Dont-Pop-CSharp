using System;
using System.Collections.Generic;
using System.Text;

namespace Francesco_Valentini
{
    /// Class used to store the scores of the best players.
    /// First, logs leaderboard length, then adds elements.
    public class Leaderboard
    {
        /// Maximum number of elements to be stored in ranking list.
        private const int RankingLength = 50;

        /// Current ranking, stored as a list.
        public List<Pair<string, int>> Ranking { get; }

        /// Builds a new object of class Leaderboard.
        public Leaderboard()
        {
            this.Ranking = new List<Pair<string, int>>();
        }

        /// Adds player to ranking, if his score is in the top scores.
        /// <param name="playerName">current player's name</param>
        /// <param name="score">current player's score after game over</param>
        public void AddToRanking(string playerName, int score)
        {
            var entry = new Pair<string, int>(playerName, score);
            if (this.Ranking.Count.Equals(0))
            {
                this.Ranking.Add(entry);
            }
            else
            {
                var index = 0;
                while (index < this.Ranking.Count)
                {
                    if (score > this.Ranking[index].e2)
                    {
                        break;
                    }
                    index++;
                }
                this.Ranking.Insert(index, entry);

                if (this.Ranking.Count > RankingLength)
                {
                    this.Ranking.RemoveAt(this.Ranking.Count - 1);
                }
            }
        }

        /// Gets the rank position of player.
        /// <param name="playerName">player name</param>
        /// <param name="score">player score</param>
        /// <returns>rank position of player, starting from 1</returns>
        public int GetRank(string playerName, int score)
        {
            for (int i = 0; i < this.Ranking.Count; i++)
            {
                if (this.Ranking[i].e1.Equals(playerName)
                    && this.Ranking[i].e2.Equals(score))
                {
                    return i + 1;
                }
            }
            return this.Ranking.Count;
        }
    }
}
