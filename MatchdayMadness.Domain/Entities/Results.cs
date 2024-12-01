using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MatchdayMadness.Domain.Models
{
    public class Results
    {
        
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
