using System;
using System.Collections.Generic;

namespace Francesco_Valentini
{
    public class ScoreManager
    {
        private Int32 _score;
        private String _playerName;
        private readonly Leaderboard _leaderboard;
        private Boolean _readOnly;

        public ScoreManager(String playerName, Int32 score, Leaderboard leaderboard)
        {
            this._score = score;
            this._playerName = playerName;
            this._leaderboard = leaderboard;

            this._leaderboard.Load();
            this._leaderboard.AddToRanking(_playerName, _score);

            this._leaderboard.Save();
        }

        public ScoreManager(Leaderboard leaderboard)
        {
            this._readOnly = true;
            this._leaderboard = leaderboard;

            this._leaderboard.Load();
        }

        public List<Pair<String, Int32>> GetRanking()
        {
            return this._leaderboard.GetRanking();
        }

        public String GetPlayerName()
        {
            return this._playerName;
        }

        public Int32 GetScore()
        {
            return this._score;
        }

        public String GetRank()
        {
            return this._leaderboard.GetRank(GetPlayerName(), GetScore()).ToString();
        }

        public bool IsReadOnly()
        {
            return this._readOnly;
        }
    }
}