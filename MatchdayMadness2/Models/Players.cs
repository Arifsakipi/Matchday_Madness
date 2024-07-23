using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchdayMadness2.Models
{
    public class Players
    { 
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime Age { get; set; }

        public virtual List<Favorites> Favorites { get; set; }


        [ForeignKey("Teams")]
        [DisplayName("Team")]
        public int? Teamsid { get; set; }

        public virtual Teams Teams { get; set; }
    }
}
