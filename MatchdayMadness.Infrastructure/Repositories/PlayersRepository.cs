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
    public class PlayersRepository : GenericRepository<Players>, IPlayersRepository
    {
        private DB _db;
        public PlayersRepository(DB contex) : base(contex)
        {
            _db = contex;
        }
    }
}
