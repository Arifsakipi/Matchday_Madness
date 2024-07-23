using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchdayMadness2.Models
{
    public class LiveMatchUpdates
    {
        [Key]
        public int id { get; set; }
        public int CurrenScoreHome { get; set; }
        public int CurrenScoreAway { get; set; }
        public DateTime CurrentTime { get; set; }


        [ForeignKey("id")]
        public int? Notificationsid { get; set; }
        public int? Matchesid { get; set; }


        public virtual Notifications Notifications { get; set; }
        public virtual Matches Matches { get; set; }
    }
}
