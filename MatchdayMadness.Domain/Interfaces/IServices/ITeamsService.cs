using MatchdayMadness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchdayMadness.Domain.Interfaces.IServices
{
    public interface ITeamsService
    {
        public Task<IEnumerable<Teams>> GetTeam();
        public Task<Teams> GetTeamById(int id);
        Task<Teams> CreateTeam(Teams newUser);
        Task<Teams> UpdateTeam(Teams userNewData);
        Task<Teams> DeleteTeam(int id);
    }
}
