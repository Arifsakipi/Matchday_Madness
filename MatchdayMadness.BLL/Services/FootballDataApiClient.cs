using MatchdayMadness.BLL.Models.RequestModels;
using MatchdayMadness.BLL.Models.Response;
using MatchdayMadness.Domain.Interfaces.IServices;
using MatchdayMadness.Domain.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.Json;

namespace MatchdayMadness.BLL.Services
{
    public class FootballDataApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public FootballDataApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["FootballDataApi:ApiKey"];
            _httpClient.BaseAddress = new Uri(configuration["FootballDataApi:BaseUrl"]);
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", _apiKey);
        }

        public async Task<Teams> GetTeamByExternalIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"teams/{id}");
            response.EnsureSuccessStatusCode();

            var teamData = await response.Content.ReadFromJsonAsync<Teams>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return teamData;
        }

        public async Task<IEnumerable<TeamRequestModel>> GetTeamsAsync()
        {
            var response = await _httpClient.GetAsync("teams");
            response.EnsureSuccessStatusCode();

            var teamsResponse = await response.Content.ReadFromJsonAsync<TeamsResponse>();
            return teamsResponse?.Teams ?? new List<TeamRequestModel>();
        }

    }
}
