using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MatchdayMadness.Domain.Models
{
    public class Teams
    {
       
        public int id { get; set; }
        public string? Name { get; set; }
        public string? League { get; set; }
        public string? Coach { get; set; }
        public string? Formation { get; set; }
        public string?  Stadium { get; set; }
        public int? MatchesPlayed { get; set; }
        public int? Wins { get; set; }
        public int? Loses { get; set; }
        public int? Draws { get; set; }

        [JsonIgnore]
        public virtual List<Players>? Players { get; set; }
        [JsonIgnore]
        public virtual List<Favorites>? Favorites { get; set; }
        [JsonIgnore]
        public virtual List<Matches>? Matches { get; set; }
        [JsonIgnore]
        public virtual List<Table>? Tables { get; set; }
        [JsonIgnore]
        public virtual List<Matches>? HomeMatches { get; set; }
        [JsonIgnore]
        public virtual List<Matches>? AwayMatches { get; set; }
    }
}
