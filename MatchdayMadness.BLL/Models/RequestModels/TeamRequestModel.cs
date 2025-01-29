using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatchdayMadness.BLL.Models.RequestModels
{
    public class TeamRequestModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("league")]
        public string? League { get; set; }

        [JsonPropertyName("coach")]
        public string? Coach { get; set; }

        [JsonPropertyName("formation")]
        public string? Formation { get; set; }

        [JsonPropertyName("stadium")]
        public string? Stadium { get; set; }

        [JsonPropertyName("matchesPlayed")]
        public int? MatchesPlayed { get; set; }

        [JsonPropertyName("wins")]
        public int? Wins { get; set; }

        [JsonPropertyName("loses")]
        public int? Loses { get; set; }

        [JsonPropertyName("draws")]
        public int? Draws { get; set; }
    }
}
