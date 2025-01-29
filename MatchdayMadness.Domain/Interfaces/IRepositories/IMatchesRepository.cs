using MatchdayMadness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchdayMadness.Domain.Interfaces.IRepositories
{
    public interface IMatchesRepository : IGenericRepository<Matches>
    {
        IQueryable<Matches> Search(string query);
        Task<List<Matches>> GetMatchesAsync();

        Task<List<Matches>> GetTeamMatches(int teamid);
    }
}
