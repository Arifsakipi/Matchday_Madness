using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MatchdayMadness2.Models
{
    public class Results
    {
        [Key]
        public int id { get; set; }
        public string Details { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }
        public string Events { get; set; }


        [ForeignKey("id")]
        public int? Matchesid { get; set; } 


        public virtual Matches Matches { get; set; }

    }
}
