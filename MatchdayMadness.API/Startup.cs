using MatchdayMadness.BLL.Services;
using MatchdayMadness.Domain.Interfaces.IRepositories;
using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using MatchdayMadness.Infrastructure.Data;
using MatchdayMadness.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MatchdayMadness.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITeamsRepository, TeamsRepository>();
            services.AddScoped<ITeamsService, TeamsService>();

            services.AddScoped<IPlayersRepository, PlayersRepository>();
            services.AddScoped<IPlayersService, PlayersService>();

            services.AddScoped<IMatchesRepository, MatchesRepository>();
            services.AddScoped<IMatchesService, MatchesService>();

        }
    }
}
