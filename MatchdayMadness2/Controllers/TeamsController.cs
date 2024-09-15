using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace MatchdayMadness2.Controllers
{
    public class TeamsController : Controller
    {
        private List<Teams> teams = new List<Teams>();
        private static DB _db;
        public TeamsController(DB db)
        {
            _db = db;
        }
        // GET: TeamsController
        public ActionResult Index()
        {
            var teams = _db.Teams.Include(x => x.League);
            return View(teams);
        }

        // GET: TeamsController/Details/5
        public ActionResult Details(int id)
        {
            var teams = _db.Teams.Include(x=>x.League).Where(x => x.id.Equals(id)).SingleOrDefault();
            return View(teams);
        }

        // GET: TeamsController/Create
        public ActionResult Create()
        {
            var leagues = _db.League.ToList();
            var leagueSelectList = new SelectList(leagues, "LeagueId", "Name");
            ViewBag.league = leagueSelectList; 
            return View();
        }

        // POST: TeamsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teams newTeam)
        {
            _db.Teams.Add(newTeam);
            _db.SaveChanges();
            return RedirectToAction("Index");   
        }

        // GET: TeamsController/Edit/5
        public ActionResult Edit(int id)
        {
            var team1 = _db.Teams.Find(id);
            var league = _db.League.ToList();
            var leagueSelectList = new SelectList(league, "LeagueId", "Name",team1.LeagueId);
            ViewBag.league = leagueSelectList;
            return View(team1);
        }

        // POST: TeamsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teams teamsNewData)
        {
            try
            {
                var team1 = _db.Teams.Find(teamsNewData.id);
                if (team1 != null)
                {
                    team1.Name = teamsNewData.Name;
                    team1.LeagueId = teamsNewData.LeagueId;
                    team1.Coach = teamsNewData.Coach;
                    team1.MatchesPlayed = teamsNewData.MatchesPlayed;
                    team1.Stadium = teamsNewData.Stadium;
                    team1.Formation = teamsNewData.Formation;    
                    team1.Wins = teamsNewData.Wins;
                    team1.Loses = teamsNewData.Loses;
                    team1.Draws = teamsNewData.Draws;
                }else
                 {
                    return View();
                 }
                _db.SaveChanges();   
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamsController/Delete/5
        public ActionResult Delete(int id)
        {
            var team1 = _db.Teams.Find(id);
            return View(team1);
        }

        // POST: TeamsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var team1 = _db.Teams.Find(id);
                if (team1 != null)
                {
                    _db.Teams.Remove(team1);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
                
            }
            
           
            catch
            {
                return View("Index");
            }
        }
    }
}
