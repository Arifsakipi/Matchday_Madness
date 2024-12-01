using MatchdayMadness.Domain.Interfaces.IRepositories;
using MatchdayMadness.Domain.Models;
using MatchdayMadness.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;



namespace MatchdayMadness.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private DB _db;
        public UserRepository(DB context) : base(context)
        {
            _db = context;
        }
    }
}
