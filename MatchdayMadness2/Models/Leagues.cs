using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MatchdayMadness2.Models
{
    public class Leagues
    {
        [Key]
        public int LeagueId { get; set; }
        public string Name { get; set; }

    }
}
