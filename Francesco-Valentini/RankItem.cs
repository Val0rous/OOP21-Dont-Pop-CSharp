using System;

namespace DontPop
{
    public class RankItem
    {
        private readonly String _rank;
        private readonly String _name;
        private readonly Integer _score;

        public RankItem (String rank, String name, Int32 score)
        {
            _rank = rank;
            _name = name;
            _score = score;
        }

        public String GetRank()
        {
            return _rank;
        }

        public String GetName()
        {
            return _name;
        }

        public Int32 GetScore()
        {
            return _score;
        }
    }
}