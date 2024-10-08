﻿using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MatchdayMadness2.Controllers
{
    public class MatchesController : Controller
    {
        private static DB _db;
        public MatchesController(DB db)
        {
            _db = db;
        }
        private static List<Matches> matches = new List<Matches>();
        // GET: MatchesController
        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Json(new List<object>()); // Return an empty list if query is empty
            }

            var matches = _db.Matches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Where(m => m.HomeTeam.Name.Contains(query) || m.AwayTeam.Name.Contains(query))
                .Select(m => new
                {
                    id = m.id,
                    HomeTeam = m.HomeTeam.Name,
                    AwayTeam = m.AwayTeam.Name,
                    Date = m.Date.ToString("dd MMMM, yyyy"),
                    Stadium = m.Stadium,
                    Status = m.Status
                })
                .ToList();

            return Json(matches); // Return the matches as JSON
        }

        public ActionResult Index()
        {
            matches = _db.Matches.
                Include(x=>x.HomeTeam).Include(x=>x.AwayTeam).ToList();
            return View(matches);
        }

        // GET: MatchesController/Details/5
        public ActionResult Details(int id)
        {
            var match = _db.Matches.Include(x => x.HomeTeam).Include(x => x.AwayTeam).Where(x => x.id.Equals(id)).SingleOrDefault();
            return View(match);
        }

        // GET: MatchesController/Create
        public ActionResult Create()
        {
            ViewBag.HomeTeam = new SelectList(_db.Teams, "id", "Name");
            ViewBag.AwayTeam=new SelectList(_db.Teams,"id","Name");
            ViewBag.Stadiums = new SelectList(_db.Teams, "Stadium","Stadium");
            ViewBag.Status = new SelectList(new List<string> { "Ongoing", "Upcoming", "Finished"});

            return View();
        }

        // POST: MatchesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Matches newMatches)
        {
            {
                _db.Matches.Add(newMatches);
                _db.SaveChanges();
                ViewBag.HomeTeam=new SelectList(_db.Teams,"id","Name",newMatches.HomeTeamid);
                ViewBag.AwayTeam=new SelectList(_db.Teams,"id","Name",newMatches.AwayTeamid);
                ViewBag.Stadiums = new SelectList(_db.Teams, "Stadium","Stadium");
                ViewBag.Status = new SelectList(new List<string> { "Ongoing", "Upcoming", "Finished" });

                return RedirectToAction("Index");
            }
        }

        // GET: MatchesController/Edit/5
        public ActionResult Edit(int id)
        {
            var matches1 = _db.Matches.Find(id);
            ViewBag.HomeTeam = new SelectList(_db.Teams, "id", "Name");
            ViewBag.AwayTeam = new SelectList(_db.Teams, "id", "Name");
            ViewBag.Stadiums = new SelectList(_db.Teams, "Stadium", "Stadium");
            ViewBag.Status = new SelectList(new List<string> { "Ongoing", "Upcoming", "Finished" });

            return View(matches1);
        }

        // POST: MatchesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Matches matchesNewData)
        {
            try
            {
                var matches1 = _db.Matches.Find(matchesNewData.id);
                ViewBag.HomeTeam = new SelectList(_db.Teams, "id", "Name", matchesNewData.HomeTeamid);
                ViewBag.AwayTeam = new SelectList(_db.Teams, "id", "Name", matchesNewData.AwayTeamid);
                ViewBag.Stadiums = new SelectList(_db.Teams, "Stadium", "Stadium");
                ViewBag.Status = new SelectList(new List<string> { "Ongoing", "Upcoming", "Finished" });

                if (matches1 != null)
                {
                    matches1.Stadium = matchesNewData.Stadium;
                    matches1.Date = matchesNewData.Date;
                    matches1.Result = matchesNewData.Result;
                    matches1.Status = matchesNewData.Status;
                    matches1.HomeTeamid = matchesNewData.HomeTeamid;
                    matches1.AwayTeamid = matchesNewData.AwayTeamid;
                    matches1.Stadium = matchesNewData.Stadium;
                   
                    _db.SaveChanges();
                }
                else
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

        // GET: MatchesController/Delete/5
        public ActionResult Delete(int id)
        {
            var matches1 = _db.Matches.Find(id);
            return View(matches1);
        }

        // POST: MatchesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var matches1 = _db.Matches.Find(id);
                if (matches1 != null)
                {
                    _db.Matches.Remove(matches1);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
