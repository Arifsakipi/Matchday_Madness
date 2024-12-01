using MatchdayMadness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchdayMadness.Domain.Interfaces.IServices
{
    public interface IPlayersService
    {
        public Task<IEnumerable<Players>> GetPlayer();
        public Task<Players> GetPlayerById(int id);
        Task<Players> CreatePlayer(Players newPlayer);
        Task<Players> UpdatePlayer(Players PlayerNewData);
        Task<Players> DeletePlayer(int id);
    }
}
