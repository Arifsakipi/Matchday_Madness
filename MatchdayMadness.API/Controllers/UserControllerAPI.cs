using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatchdayMadness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllerAPI : ControllerBase
    {
        private IUserService _userService;
        public UserControllerAPI(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserControllerAPI>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _userService.GetUser();
        }
        [HttpGet("{id}")]
        public async Task<User> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPost]
        public async Task<User> CreateUser(User newUser)
        {
            return await _userService.CreateUser(newUser);
        }

        [HttpPut]   
        public async Task<User> UpdateUser(User userNewData)
        {
            return await _userService.UpdateUser(userNewData);
        }
        [HttpDelete]
        public async Task<User> DeleteUser(int id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}   