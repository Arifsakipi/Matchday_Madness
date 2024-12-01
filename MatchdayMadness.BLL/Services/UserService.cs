using BCrypt.Net;
using MatchdayMadness.Domain.Interfaces.IRepositories;
using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MatchdayMadness.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Retrieve all users
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _userRepository.GetAllAsync();
        }

        // Retrieve a user by ID
        public async Task<User> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }

        // Create a new user
        public async Task<User> CreateUser(User newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser));

            await _userRepository.AddAsync(newUser); 
            return newUser;
        }

        // Update an existing user
        public async Task<User> UpdateUser(User userNewData)
        {
            if (userNewData == null)
                throw new ArgumentNullException(nameof(userNewData));

            await _userRepository.UpdateAsync(userNewData);
            return userNewData;
        }

        // Delete a user by ID
        public async Task<User> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            await _userRepository.RemoveAsync(user);
            return user;      
        }

    }
}
