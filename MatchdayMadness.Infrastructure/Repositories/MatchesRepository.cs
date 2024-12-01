using MatchdayMadness.Domain.Interfaces.IRepositories;
using MatchdayMadness.Domain.Models;
using MatchdayMadness.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchdayMadness.Infrastructure.Repositories
{
    public class MatchesRepository : GenericRepository<Matches>, IMatchesRepository
    {
        private DB _db;
        public MatchesRepository(DB context) : base(context)
        {
            _db = context;
        }

        public IQueryable<Matches> Search(string query)
        {
            return (IQueryable<Matches>)_db.Matches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Where(m => m.HomeTeam.Name.Contains(query) || m.AwayTeam.Name.Contains(query));               
        }
    }
}
