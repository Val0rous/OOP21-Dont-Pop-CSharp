using System;
using System.Collections.Generic;

namespace Francesco_Valentini
{
    /// ScoreManager calculates the current score.
    /// Edits table values.
    public class ScoreManager
    {
        /// Player score (at gameover).
        public int Score { get; }

        /// Current player's name.
        public string PlayerName { get; }

        /// Read only status: if true, leaderboard ranking will not be modified.
        /// If false, the ScoreManager is able to edit the leaderboard ranking.
        public bool ReadOnly { get; }

        private readonly Leaderboard _leaderboard;

        /// Creates & initializes this class.
        /// <param name="playerName">current player's name</param>
        /// <param name="score">current player's score</param>
        /// <param name="leaderboard">leaderboard manager (edit mode)</param>
        public ScoreManager(string playerName, int score, Leaderboard leaderboard)
        {
            this.Score = score;
            this.PlayerName = playerName;
            this._leaderboard = leaderboard;

            this._leaderboard.AddToRanking(PlayerName, Score);
        }

        /// This constructor is useful when all you want to do is to view current leaderboard, without editing it.
        /// <param name="leaderboard">leaderboard manager (readonly mode)</param>
        public ScoreManager(Leaderboard leaderboard)
        {
            this.ReadOnly = true;
            this._leaderboard = leaderboard;
        }

        /// Gets a copy of the ranking list inside Leaderboard.
        /// <returns>current ranking list</returns>
        public List<Pair<string, int>> GetRanking() => this._leaderboard.Ranking;

        /// Gets current player's rank (at gameover).
        /// <returns>current player rank</returns>
        public int GetRank() => this._leaderboard.GetRank(this.PlayerName, this.Score);
    }
}