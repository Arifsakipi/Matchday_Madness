using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsControllerAPI : ControllerBase
    {
        private ITeamsService _teamsService;
        public TeamsControllerAPI(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        //[HttpGet("FetchTeamFromExternalApi/{externalId}")]
        //public async Task<Teams> FetchTeamFromExternalApi(int externalId)
        //{
        //    return await _teamsService.FetchTeamFromExternalApi(externalId);
        //}

        //[HttpGet("FetchAllTeamsFromExternalApi")]
        //public async Task<IEnumerable<Teams>> FetchAllTeamsFromExternalApi()
        //{
        //    return await _teamsService.FetchAllTeamsFromExternalApi();
        //}

        [HttpGet("GetTeams")]
        public async Task<IEnumerable<Teams>> GetTeams()
        {
            return await _teamsService.GetTeam();
        }

        [HttpGet("GetTeamById/{id}")]
        public async Task<Teams> GetTeamById(int id)
        {
            return await _teamsService.GetTeamById(id);
        }

        [HttpPost("CreateTeam")]
        public async Task<Teams> CreateTeam(Teams newTeam)
        {
            return await _teamsService.CreateTeam(newTeam);
        }

        [HttpPut("UpdateTeam")]
        public async Task<Teams> UpdateTeam(Teams teamNewData)
        {
            return await _teamsService.UpdateTeam(teamNewData);
        }

        [HttpDelete("DeleteTeam/{id}")]
        public async Task<Teams> DeleteTeam(int id)
        {
            return await _teamsService.DeleteTeam(id);
        }
    }
}
