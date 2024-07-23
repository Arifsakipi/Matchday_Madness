using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchdayMadness2.Models
{
    public class Notifications
    {
        [Key]
        public int id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public bool IsRead { get; set; }

        [ForeignKey("id")]
        public int? Userid { get; set; }
        public virtual User Users { get; set; }


        public virtual List<LiveMatchUpdates> LiveMatchUpdates { get; set; }

    }
}
