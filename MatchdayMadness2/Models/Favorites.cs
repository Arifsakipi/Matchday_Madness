using LinqToTwitter;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchdayMadness2.Models
{
    public class Favorites
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("id")]
        [DisplayName("Teams")]
        public int? Teamsid { get; set; }
        [DisplayName("Players")]
        public int? PlayersID { get; set; }
        public int? Userid { get; set; }

        public virtual Teams Teams { get; set; }
        public virtual Players Players { get; set; }
        public virtual User Users { get; set; }
    }
}
