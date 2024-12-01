using MatchdayMadness.Domain.Interfaces.IRepositories;
using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchdayMadness.BLL.Services
{
    public class MatchesService : IMatchesService
    {
        private readonly IMatchesRepository _matchesRepository;

        public MatchesService(IMatchesRepository matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }

        public async Task<IEnumerable<Matches>> GetMatch()
        {
            return await _matchesRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Matches>> SearchMatches(string query)
        {
            var matches = await _matchesRepository.Search(query).ToListAsync();
            return matches.Select(m => new Matches
            {
                id = m.id,
                HomeTeam = m.HomeTeam,
                AwayTeam = m.AwayTeam,
                Date = m.Date,
                Stadium = m.Stadium,
                Status = m.Status
            });      
        }   

        public async Task<Matches> GetMatchById(int id)
        {
            var match = await _matchesRepository.GetByIdAsync(id);
            return match;
        }

        public async Task<Matches> CreateMatch(Matches newMatch)
        {
            if (newMatch == null)
                throw new ArgumentNullException(nameof(newMatch));

            await _matchesRepository.AddAsync(newMatch);
            return newMatch;
        }

        public async Task<Matches> UpdateMatch(Matches matchNewData)
        {
            if (matchNewData == null)
                throw new ArgumentNullException(nameof(matchNewData));

            await _matchesRepository.UpdateAsync(matchNewData);
            return matchNewData;
        }

        public async Task<Matches> DeleteMatch(int id)
        {
            var match = await _matchesRepository.GetByIdAsync(id);
            await _matchesRepository.RemoveAsync(match);
            return match;
        }
    }
}
