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
        private const Int32 RankingLength = 50;
        private List<Pair<String, Int32>> _ranking = new List<Pair<string, Int32>>();

        /// <summary>
        /// Builds a new object of class Leaderboard.
        /// </summary>
        public Leaderboard()
        {

        }

        /// <summary>
        /// Gets a copy of current ranking.
        /// </summary>
        /// <returns>current ranking</returns>
        public List<Pair<String, Int32>> GetRanking()
        {
            var copy = this._ranking;
            return copy;
        }

        /// <summary>
        /// Adds player to ranking, if his score is in the top scores.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
        public void AddToRanking(String playerName, Int32 score)
        {
            var entry = new Pair<String, Int32>(playerName, score);
            if (this._ranking.Count.Equals(0))
            {
                this._ranking.Add(entry);
            }
            else
            {
                int index = 0;
                while (index < this._ranking.Count)
                {
                    if (score > this._ranking[index].Get2())
                    {
                        break;
                    }
                    index++;
                }
                this._ranking.Insert(index, entry);

                if (this._ranking.Count > RankingLength)
                {
                    this._ranking.RemoveAt(this._ranking.Count - 1);
                }
            }
        }

        /// <summary>
        /// Gets the rank position of player.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public Int32 GetRank(String playerName, Int32 score)
        {
            for (int i = 0; i < this._ranking.Count; i++)
            {
                if (this._ranking[i].Get1().Equals(playerName)
                    && this._ranking[i].Get2().Equals(score))
                {
                    return i + 1;
                }
            }
            return this._ranking.Count;
        }

        /// <summary>
        /// Loads ranking saved in the savefile.
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// Saves current ranking in the savefile.
        /// </summary>
        public void Save()
        {

        }
    }
}
