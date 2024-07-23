using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness2.Controllers
{
    public class StandingsController : Controller
    {
        private static List<Standings> standings = new List<Standings>();
        // GET: StandingsController
        public ActionResult Index()
        {
            return View(standings);
        }

        // GET: StandingsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StandingsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StandingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Standings newStanding)
        {           
            {
                standings.Add(newStanding);
                return RedirectToAction("Index");
            }
        }

        // GET: StandingsController/Edit/5
        public ActionResult Edit(int id)
        {
            var standing1 = standings.Find(x => x.id == id);
            return View(standing1);
        }

        // POST: StandingsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Standings standingsNewData)
        {
            try
            {
                var standing1 = standings.Find(x => x.id == standingsNewData.id);
                if (standing1 != null)
                {
                    standing1.Position = standingsNewData.Position;
                    standing1.Team = standingsNewData.Team;
                    standing1.Points = standingsNewData.Points;
                    standing1.MatchesPlayed = standingsNewData.MatchesPlayed;
                    standing1.Wins = standingsNewData.Wins;
                    standing1.Loses = standingsNewData.Loses;
                    standing1.Draws = standingsNewData.Draws;
                    standing1.GoalDifference = standingsNewData.GoalDifference;
                }else
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StandingsController/Delete/5
        public ActionResult Delete(int id)
        {
            var standing1 = standings.Find(x => x.id == id);
            return View(standing1);
        }

        // POST: StandingsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var standing1 = standings.Find(x => x.id == id);
                if (standing1 != null) 
                    standings.Remove(standing1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
