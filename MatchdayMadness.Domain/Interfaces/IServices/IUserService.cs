using MatchdayMadness.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchdayMadness.Domain.Interfaces.IServices
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetUser();
        public Task<User> GetUserById(int id);
        Task<User> CreateUser(User newUser);
        Task<User> UpdateUser(User userNewData);
        Task<User> DeleteUser(int id);
    }
}
  