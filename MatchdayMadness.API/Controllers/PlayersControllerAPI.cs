using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersControllerAPI : ControllerBase
    {
        private readonly IPlayersService _playersService;
        public PlayersControllerAPI(IPlayersService playersService)
        {
            _playersService = playersService;
        }

        [HttpGet("GetPlayer")]
        public async Task<IEnumerable<Players>> GetPlayer()
        {
            return await _playersService.GetPlayer();
        }

        [HttpGet("GetPlayerById/{id}")]
        public async Task<Players> GetPlayerById(int id)
        {
            return await _playersService.GetPlayerById(id);
        }

        [HttpPost("CreatePlayer")]
        public async Task<Players> CreatePlayer(Players newPlayer)
        {
            return await _playersService.CreatePlayer(newPlayer);
        }

        [HttpPut("UpdatePlayer")]
        public async Task<Players> UpdatePlayer(Players playerNewData)
        {
            return await _playersService.UpdatePlayer(playerNewData);
        }

        [HttpDelete("DeletePlayer/{id}")]
        public async Task<Players> DeletePlayer(int id)
        {
            return await _playersService.DeletePlayer(id);
        }
    }
}
