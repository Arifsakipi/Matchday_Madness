using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MatchdayMadness2.Models
{
    public class Table
    {
        [Key]
        public int id { get; set; }
        public string LeagueName { get; set; }
        [ForeignKey("Teams")]
        public int Teamsid { get; set; }
        public string Standings { get; set; }


       
        


        public virtual Teams Team { get; set; }
    }
}
