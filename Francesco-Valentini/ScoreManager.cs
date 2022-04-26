using System;

namespace DontPop
{
    public class ScoreManager
    {
        private Int32 _score;
        private String _playerName;
        private readonly Leaderboard _leaderboard;
        private readonly GameApplication _application;
        private Boolean _readOnly;

        public ScoreManager(String playerName, Int32 score, Leaderboard leaderboard, GameApplication application)
        {
            _score = score;
            _playerName = playerName;
            _leaderboard = leaderboard;
            _application = application;

            _leaderboard.Load();
            _leaderboard.AddToRanking(_playerName, _score);

            _leaderboard.Save();
        }

        public ScoreManager(Leaderboard leaderboard, GameApplication application)
        {
            _readOnly = true;
            _leaderboard = leaderboard;
            _application = application;

            _leaderboard.Load();
        }

        public List<Pair<String, Int32>> GetRanking()
        {
            return _leaderboard.GetRanking();
        }

        public String GetPlayerName()
        {
            return _playerName;
        }

        public Int32 GetScore()
        {
            return _score;
        }

        public String GetRank()
        {
            return _leaderboard.GetRank(GetPlayerName(), GetScore()).ToString();
        }
    }
}