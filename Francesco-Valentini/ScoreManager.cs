using System;
using System.Collections.Generic;

namespace Francesco_Valentini
{
    /// <summary>
    /// ScoreManager calculates the current score.
    /// Edits table values.
    /// </summary>
    public class ScoreManager
    {
        public int Score { get; }
        public string PlayerName { get; }
        public bool ReadOnly { get; private set; }
        private readonly Leaderboard _leaderboard;

        /// <summary>
        /// Creates & initializes this class.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
        /// <param name="leaderboard"></param>
        public ScoreManager(string playerName, int score, Leaderboard leaderboard)
        {
            this.Score = score;
            this.PlayerName = playerName;
            this._leaderboard = leaderboard;

            this._leaderboard.AddToRanking(PlayerName, Score);
        }

        /// <summary>
        /// This constructor is useful when all you want to do is to view current leaderboard, without editing it.
        /// </summary>
        /// <param name="leaderboard"></param>
        public ScoreManager(Leaderboard leaderboard)
        {
            this.ReadOnly = true;
            this._leaderboard = leaderboard;
        }

        /// <summary>
        /// Gets a copy of the ranking list inside Leaderboard.
        /// </summary>
        /// <returns>current ranking</returns>
        public List<Pair<string, int>> GetRanking() => this._leaderboard.Ranking;

        /// <summary>
        /// Gets current player's rank (at gameover).
        /// </summary>
        /// <returns>rank</returns>
        public int GetRank() => this._leaderboard.GetRank(this.PlayerName, this.Score);
    }
}