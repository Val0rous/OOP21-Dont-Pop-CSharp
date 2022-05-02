using System;

namespace Francesco_Valentini
{
    /// <summary>
    /// Useful class to keep all infos about a rank entry in the ScoreScene table.
    /// </summary>
    public class RankItem
    {
        private readonly int _rank;
        private readonly string _name;
        private readonly int _score;

        /// <summary>
        /// Builds a new object for this class.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public RankItem (int rank, string name, int score)
        {
            this._rank = rank;
            this._name = name;
            this._score = score;
        }

        /// <summary>
        /// Gets rank of current entry.
        /// </summary>
        /// <returns>rank</returns>
        public int GetRank() => this._rank;

        /// <summary>
        /// Gets name of current entry.
        /// </summary>
        /// <returns>name</returns>
        public string GetName() => this._name;

        /// <summary>
        /// Gets score of current entry.
        /// </summary>
        /// <returns>score</returns>
        public int GetScore() => this._score;
    }
}