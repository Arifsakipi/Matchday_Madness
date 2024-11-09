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
    public class UserRepository : IUserRepository
    {
        private static DB _db;
        public UserRepository(DB db)
        {
            _db = db;
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            return await Task.FromResult(_db.Users);
        }
    }
}
