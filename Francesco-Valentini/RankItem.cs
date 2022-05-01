using System;

namespace Francesco_Valentini
{
    public class RankItem
    {
        private readonly string _rank;
        private readonly string _name;
        private readonly int _score;

        public RankItem (string rank, string name, int score)
        {
            this._rank = rank;
            this._name = name;
            this._score = score;
        }

        public String GetRank()
        {
            return this._rank;
        }

        public String GetName()
        {
            return this._name;
        }

        public Int32 GetScore()
        {
            return this._score;
        }
    }
}