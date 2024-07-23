using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchdayMadness2.Models
{
    public class LiveCommentary
    {
        [Key]
        public int id { get; set; }
        public string Commentator { get; set; }
        public string DescriptiveText { get; set; }
        public bool RealTimeUpdates { get; set; }


        [ForeignKey("id")]
        public int? Matchesid { get; set; }
        public Matches Matches { get; set; }
    }
}
