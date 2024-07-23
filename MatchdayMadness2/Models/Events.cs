using System.ComponentModel.DataAnnotations;

namespace MatchdayMadness2.Models
{
    public class Events
    {
        [Key]
        public int id { get; set; }
        public int Goals { get; set; }
        public int Shots { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int Fouls { get; set; }
        public string Substitutions { get; set; }
        public int Corners { get; set; }
        public int FreeKicks { get; set; }
        public float Possession { get; set; }

    }
}
