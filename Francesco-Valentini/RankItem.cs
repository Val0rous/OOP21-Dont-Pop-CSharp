using System;

namespace Francesco_Valentini
{
    /// <summary>
    /// Useful class to keep all infos about a rank entry in the ScoreScene table.
    /// </summary>
    public class RankItem
    {
        /// Player rank.
        public int Rank { get; }
        
        /// Player name.
        public string Name { get; }
        
        /// Player score.
        public int Score { get; }

        /// Builds a new object for this class.
        /// <param name="rank">player rank</param>
        /// <param name="name">player name</param>
        /// <param name="score">player score</param>
        public RankItem (int rank, string name, int score)
        {
            this.Rank = rank;
            this.Name = name;
            this.Score = score;
        }
    }
}
