
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MatchdayMadness.Domain.Models
{
    public class Players
    { 
       
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime Age { get; set; }

        [JsonIgnore]    
        public virtual List<Favorites>? Favorites { get; set; }


        [ForeignKey("Teams")]
        [DisplayName("Team")]
        public int? Teamsid { get; set; }
        [JsonIgnore]
        public virtual Teams? Teams { get; set; }
    }
}
