using System;

namespace Francesco_Valentini
{
    /// <summary>
    /// Useful class to keep all infos about a rank entry in the ScoreScene table.
    /// </summary>
    public class RankItem
    {
        /// <summary>
        /// Player rank.
        /// </summary>
        public int Rank { get; }
        /// <summary>
        /// Player name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Player score.
        /// </summary>
        public int Score { get; }

        /// <summary>
        /// Builds a new object for this class.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public RankItem (int rank, string name, int score)
        {
            this.Rank = rank;
            this.Name = name;
            this.Score = score;
        }
    }
}