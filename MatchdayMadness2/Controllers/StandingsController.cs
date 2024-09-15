//using MatchdayMadness2.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;

//namespace MatchdayMadness2.Controllers
//{
//    public class StandingsController : Controller
//    {
//        private static DB _db;
//        public StandingsController(DB db)
//        {
//            _db = db;
//        }

//        private static List<Standings> standings = new List<Standings>();
//        // GET: StandingsController
//        public ActionResult Index()
//        {
//            var standings = _db.Standings
//                .Include(s => s.Leagues)
//                .Include(s => s.Teams)
//                .ToList();
//            return View(standings);
//        }

//        // GET: StandingsController/Create
//        public ActionResult Create()
//        {
//            ViewBag.Leagues = new SelectList(_db.Leagues, "LeagueId", "Name");
//            ViewBag.Teams = new SelectList(_db.Teams, "TeamId", "Name");
//            return View();
//        }

//        // POST: StandingsController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Standings standings)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.Standings.Add(standings);
//                _db.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }

//            ViewBag.Leagues = new SelectList(_db.Leagues, "LeagueId", "Name", standings.LeagueId);
//            ViewBag.Teams = new SelectList(_db.Teams, "TeamId", "Name", standings.TeamId);
//            return View(standings);
//        }

//        // GET: StandingsController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            var standings = _db.Standings.Find(id);
//            if (standings == null)
//            {
//                return NotFound();
//            }

//            ViewBag.Leagues = new SelectList(_db.Leagues, "LeagueId", "Name", standings.LeagueId);
//            ViewBag.Teams = new SelectList(_db.Teams, "TeamId", "Name", standings.TeamId);
//            return View(standings);
//        }

//        // POST: StandingsController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Standings standingsNewData)
//        {
//            if (ModelState.IsValid)
//            {
//                var standings = _db.Standings.Find(standingsNewData.id);
//                if (standings == null)
//                {
//                    return NotFound();
//                }

//                standings.LeagueId = standingsNewData.LeagueId;
//                standings.TeamId = standingsNewData.TeamId;
//                standings.Position = standingsNewData.Position;
//                standings.Points = standingsNewData.Points;
//                standings.MatchesPlayed = standingsNewData.MatchesPlayed;
//                standings.Wins = standingsNewData.Wins;
//                standings.Loses = standingsNewData.Loses;
//                standings.Draws = standingsNewData.Draws;
//                standings.GoalDifference = standingsNewData.GoalDifference;

//                _db.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }

//            ViewBag.Leagues = new SelectList(_db.Leagues, "LeagueId", "Name", standingsNewData.LeagueId);
//            ViewBag.Teams = new SelectList(_db.Teams, "TeamId", "Name", standingsNewData.TeamId);
//            return View(standingsNewData);
//        }

//        // GET: StandingsController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            var standings = _db.Standings.Find(id);
//            if (standings == null)
//            {
//                return NotFound();
//            }
//            return View(standings);
//        }

//        // POST: StandingsController/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            var standings = _db.Standings.Find(id);
//            if (standings != null)
//            {
//                _db.Standings.Remove(standings);
//                _db.SaveChanges();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}