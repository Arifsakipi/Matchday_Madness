using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchdayMadness2.Models
{
   public class Matches
    {
        [Key]
        public int id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public string Status { get; set; }
        
        [ForeignKey("HomeTeam")]
        [DisplayName("Home Team")]
        public int HomeTeamid { get; set; }
        
        [ForeignKey("AwayTeam")]
        [DisplayName("Away Team")]
        public int AwayTeamid { get; set; }
        public string Result { get; set; }
        



        public virtual Teams HomeTeam { get; set; }
        public virtual Teams AwayTeam { get; set; }
        




        public virtual List<LiveCommentary> LiveCommentaries { get; set; }
        public virtual List<LiveMatchUpdates> LiveMatchUpdates { get; set; }
        public virtual List<Results> Results { get; set; }
    }

}  

