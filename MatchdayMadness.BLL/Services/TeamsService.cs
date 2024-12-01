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
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _teamsRepository;

        public TeamsService(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        public async Task<IEnumerable<Teams>> GetTeam()
        {
            return await _teamsRepository.GetAllAsync();
        }

        public async Task<Teams> GetTeamById(int id)
        {
            var team = await _teamsRepository.GetByIdAsync(id);
            return team;
        }

        public async Task<Teams> CreateTeam(Teams newTeam)
        {
            if (newTeam == null)
                throw new ArgumentNullException(nameof(newTeam));

            await _teamsRepository.AddAsync(newTeam);
            return newTeam;
        }

        public async Task<Teams> UpdateTeam(Teams teamNewData)
        {
            if (teamNewData == null)
                throw new ArgumentNullException(nameof(teamNewData));

            await _teamsRepository.UpdateAsync(teamNewData);
            return teamNewData;
        }

        public async Task<Teams> DeleteTeam(int id)
        {
            var team = await _teamsRepository.GetByIdAsync(id);
            await _teamsRepository.RemoveAsync(team);
            return team;
        }

    }
}
