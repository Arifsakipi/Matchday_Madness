using MatchdayMadness.BLL.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatchdayMadness.BLL.Models.Response
{
    public class TeamsResponse
    {
        [JsonPropertyName("teams")]
        public List<TeamRequestModel> Teams { get; set; }
    }
}
