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
        private int _score;
        private string _playerName;
        private readonly Leaderboard _leaderboard;
        private bool _readOnly;

        /// <summary>
        /// Creates & initializes this class.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
        /// <param name="leaderboard"></param>
        public ScoreManager(string playerName, int score, Leaderboard leaderboard)
        {
            this._score = score;
            this._playerName = playerName;
            this._leaderboard = leaderboard;

            this._leaderboard.AddToRanking(_playerName, _score);
        }

        /// <summary>
        /// This constructor is useful when all you want to do is to view current leaderboard, without editing it.
        /// </summary>
        /// <param name="leaderboard"></param>
        public ScoreManager(Leaderboard leaderboard)
        {
            this._readOnly = true;
            this._leaderboard = leaderboard;
        }

        /// <summary>
        /// Gets a copy of the ranking list inside Leaderboard.
        /// </summary>
        /// <returns>current ranking</returns>
        public List<Pair<string, int>> GetRanking()
        {
            return this._leaderboard.GetRanking();
        }

        /// <summary>
        /// Gets current player name.
        /// </summary>
        /// <returns>player name</returns>
        public string GetPlayerName()
        {
            return this._playerName;
        }

        /// <summary>
        /// Gets current player's rank (at gameover).
        /// </summary>
        /// <returns>rank</returns>
        public int GetScore()
        {
            return this._score;
        }

        /// <summary>
        /// Gets current player's rank (at gameover).
        /// </summary>
        /// <returns>rank</returns>
        public int GetRank()
        {
            return this._leaderboard.GetRank(this.GetPlayerName(), this.GetScore());
        }

        /// <summary>
        /// Checks whether the leaderboard should be read-only or not.
        /// </summary>
        /// <returns>true if read-only, false if leaderboard shall be edited</returns>
        public bool IsReadOnly()
        {
            return this._readOnly;
        }
    }
}