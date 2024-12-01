using MatchdayMadness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchdayMadness.Domain.Interfaces.IServices
{
    public interface IMatchesService
    {
        public Task<IEnumerable<Matches>> GetMatch();
        Task<IEnumerable<Matches>> SearchMatches(string query);
        public Task<Matches> GetMatchById(int id);
        Task<Matches> CreateMatch(Matches newMatch);
        Task<Matches> UpdateMatch(Matches MatchNewData);
        Task<Matches> DeleteMatch(int id);
    }
}
