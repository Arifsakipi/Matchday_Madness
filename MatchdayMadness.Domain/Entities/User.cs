using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MatchdayMadness.Domain.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }


        [JsonIgnore]
        public virtual List<Favorites>? Favorites { get; set; }
        [JsonIgnore]    
        public virtual List<Notifications>? Notifications { get; set; }
    }
}
