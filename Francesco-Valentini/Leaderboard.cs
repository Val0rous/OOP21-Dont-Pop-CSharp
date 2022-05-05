using System;
using System.Collections.Generic;
using System.Text;

namespace Francesco_Valentini
{
    /// <summary>
    /// Class used to store the scores of the best players.
    /// First, logs leaderboard length, then adds elements.
    /// </summary>
    public class Leaderboard
    {
        /// <summary>
        /// Maximum number of elements to be stored in ranking list.
        /// </summary>
        private const int RankingLength = 50;

        /// <summary>
        /// Current ranking, stored as a list.
        /// </summary>
        public List<Pair<string, int>> Ranking { get; }

        /// <summary>
        /// Builds a new object of class Leaderboard.
        /// </summary>
        public Leaderboard()
        {
            this.Ranking = new List<Pair<string, int>>();
        }

        /// <summary>
        /// Adds player to ranking, if his score is in the top scores.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
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

        /// <summary>
        /// Gets the rank position of player.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
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
