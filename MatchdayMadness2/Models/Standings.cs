using System.ComponentModel.DataAnnotations;

namespace MatchdayMadness2.Models
{
    public class Standings
    {
        [Key]

        public int id { get; set; }
        public string Position { get; set; }
        public int Points { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Draws { get; set; }
        public int GoalDifference { get; set; }

        public virtual List<Leagues> Leagues { get; set; }
        public virtual List<Teams> Teams { get; set; }
    }
}
