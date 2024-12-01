using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MatchdayMadness.Domain.Models
{
   public class Matches
    {
        
        public int id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public string Status { get; set; }
     
        public int? HomeTeamid { get; set; }
       
        public int? AwayTeamid { get; set; }
        public string Result { get; set; }



        [JsonIgnore]
        public virtual Teams? HomeTeam { get; set; }
        [JsonIgnore]
        public virtual Teams? AwayTeam { get; set; }




        [JsonIgnore]
        public virtual List<LiveCommentary>? LiveCommentaries { get; set; }
        [JsonIgnore]
        public virtual List<LiveMatchUpdates>? LiveMatchUpdates { get; set; }
        [JsonIgnore]
        public virtual List<Results>? Results { get; set; }
    }

}  

