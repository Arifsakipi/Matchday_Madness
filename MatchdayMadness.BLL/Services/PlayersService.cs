using MatchdayMadness.Domain.Interfaces.IRepositories;
using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchdayMadness.BLL.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepository _playersRepository;
        public PlayersService(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        public async Task<IEnumerable<Players>> GetPlayer()
        {
            return await _playersRepository.GetAllAsync();
        }

        public async Task<Players> GetPlayerById(int id)
        {
            var player = await _playersRepository.GetByIdAsync(id);
            return player;
        }

        public async Task<Players> CreatePlayer(Players newPlayer)
        {
            if (newPlayer == null)
                throw new ArgumentNullException(nameof(newPlayer));

            await _playersRepository.AddAsync(newPlayer);
            return newPlayer;
        }

        public async Task<Players> UpdatePlayer(Players playerNewData)
        {
            if (playerNewData == null)
                throw new ArgumentNullException(nameof(playerNewData));

            await _playersRepository.UpdateAsync(playerNewData);
            return playerNewData;
        }

        public async Task<Players> DeletePlayer(int id)
        {
            var player = await _playersRepository.GetByIdAsync(id);
            if (player == null)
                throw new ArgumentNullException(nameof(player));
            await _playersRepository.RemoveAsync(player);
            return player;
        }
    }
}
