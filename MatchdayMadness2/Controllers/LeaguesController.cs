using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MatchdayMadness2.Controllers
{
    public class LeaguesController : Controller
    {
        private static DB _db;
        public LeaguesController(DB db)
        {
            _db = db;
        }

        // GET: LeaguesController
        public ActionResult Index()
        {
            var leagues = _db.Leagues.ToList();
                
            return View(leagues);
        }

        // GET: LeaguesController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: LeaguesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Leagues newleague)
        {
           _db.Leagues.Add(newleague);
            _db.SaveChanges();
            return RedirectToAction("Index");   
        }

        // GET: LeaguesController/Edit/5
        public ActionResult Edit(int id)
        {
            var league1=_db.Leagues.Find(id);

            return View(league1);
        }

        // POST: LeaguesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Leagues leaguenewdata)
        {
            try
            {
                var league1 = _db.Leagues.Find(leaguenewdata.LeagueId);
                if(league1!=null)
                {
                    league1.Name = leaguenewdata.Name;
                    
                }
                else
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

        // GET: LeaguesController/Delete/5
        public ActionResult Delete(int id)
        {
            var league1 = _db.Leagues.Find(id);
            return View(league1);
        }

        // POST: LeaguesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var league1 = _db.Leagues.Find(id);
                if (league1 != null)
                {
                    _db.Leagues.Remove(league1);

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

