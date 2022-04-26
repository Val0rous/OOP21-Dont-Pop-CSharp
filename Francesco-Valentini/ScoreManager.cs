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
    }
}