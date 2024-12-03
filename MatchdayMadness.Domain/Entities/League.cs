using System.ComponentModel.DataAnnotations;
namespace MatchdayMadness2.Domain
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; } 

        public string Name { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
