using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesControllerAPI : ControllerBase
    {
        private IMatchesService _matchesService;
        public MatchesControllerAPI(IMatchesService matchesService)
        {
            _matchesService = matchesService;
        }

        [HttpGet("GetMatches")]
        public async Task<IEnumerable<Matches>> GetMatch()
        {
            return await _matchesService.GetMatch();
        }

        [HttpGet("SearchMatches")]
        public async Task<IEnumerable<Matches>> SearchMatches(string query)
        {
            return await _matchesService.SearchMatches(query);
        }

        [HttpGet("GetMatchById/{id}")]
        public async Task<Matches> GetMatchById(int id)
        {
            return await _matchesService.GetMatchById(id);
        }

        [HttpPost("CreateMatch")]
        public async Task<Matches> CreateMatch(Matches newMatch)
        {
            return await _matchesService.CreateMatch(newMatch);
        }

        [HttpPut("UpdateMatch")]
        public async Task<Matches> UpdateMatch(Matches matchNewData)
        {
            return await _matchesService.UpdateMatch(matchNewData);
        }

        [HttpDelete("DeleteMatch/{id}")]
        public async Task<Matches> DeleteMatch(int id)
        {
            return await _matchesService.DeleteMatch(id);
        }
    }
}
