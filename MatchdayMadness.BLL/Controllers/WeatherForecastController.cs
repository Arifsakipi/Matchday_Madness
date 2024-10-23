using Microsoft.AspNetCore.Mvc;
using MatchdayMadness.BLL.Models;
namespace MatchdayMadness.BLL.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Use List<string> instead of string[]
        private static readonly List<string> Summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Count)]
                })
                .ToArray();
        }

        // POST method to add a summary
        [HttpPost("AddSummary")]
        public IActionResult AddSummary([FromBody] string newSummary)
        {
            if (string.IsNullOrWhiteSpace(newSummary))
            {
                return BadRequest("Summary cannot be empty or null.");
            }

            Summaries.Add(newSummary);
            return CreatedAtAction(nameof(Get), new { message = "Summary added successfully!" });
        }
    }
    