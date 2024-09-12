using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace MatchdayMadness2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static DB _db;

        public HomeController(ILogger<HomeController> logger, DB db)
        {
            _logger = logger;
            _db = db; //kjo quhet dependency injection design pattern
        }

        public IActionResult Index()
        {
            
            var matches = _db.Matches.Include(x => x.HomeTeam).Include(x => x.AwayTeam).OrderByDescending(x => x.Date).Take(5).ToList();

            return View(matches);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
