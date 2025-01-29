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
        private readonly IMatchesRepository _matchesRepository;
        private readonly FootballDataApiClient _apiClient;


        public TeamsService(ITeamsRepository teamsRepository, IMatchesRepository matchesRepository, FootballDataApiClient apiClient)
        {
            _teamsRepository = teamsRepository;
            _matchesRepository = matchesRepository;
            _apiClient = apiClient;
        }


        //public async Task<Teams> FetchTeamFromExternalApi(int externalId)
        //{
        //    return await _apiClient.GetTeamByExternalIdAsync(externalId);
        //}

        //public async Task<IEnumerable<Teams>> FetchAllTeamsFromExternalApi()
        //{
        //    var teamDtos = await _apiClient.GetTeamsAsync();
        //    var teams = teamDtos.Select(dto => new Teams
        //    {
        //        id = dto.Id,
        //        Name = dto.Name,
        //        League = dto.League,
        //        Coach = dto.Coach,
        //        Formation = dto.Formation,
        //        Stadium = dto.Stadium,
        //        MatchesPlayed = dto.MatchesPlayed,
        //        Wins = dto.Wins,
        //        Loses = dto.Loses,
        //        Draws = dto.Draws
        //    }).ToList();

        //    return teams;
        //}


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

            //remove related items
            //remove matches
            var teamMatches = await _matchesRepository.GetTeamMatches(id);
            if(teamMatches !=null)
            {
                if(teamMatches.Any())
                {
                    foreach(var match in teamMatches)
                    {
                        await _matchesRepository.RemoveAsync(match);
                    }
                }
            }

            //remove players

            await _teamsRepository.RemoveAsync(team);
            return team;
        }

    }
}
