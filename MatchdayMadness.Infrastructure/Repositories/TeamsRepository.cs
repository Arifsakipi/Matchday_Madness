using MatchdayMadness.Domain.Interfaces.IRepositories;
using MatchdayMadness.Domain.Models;
using MatchdayMadness.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchdayMadness.Infrastructure.Repositories
{
    public class TeamsRepository : GenericRepository<Teams>, ITeamsRepository
    {
        private DB _db;
        public TeamsRepository(DB context) : base(context)
        {
            _db = context;
        }
    }
}
