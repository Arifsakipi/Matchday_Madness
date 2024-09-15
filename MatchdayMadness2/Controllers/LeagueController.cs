using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness2.Controllers
{
    public class LeagueController : Controller
    {
        

        private List<League> league = new List<League>();
        private static DB _db;
        public LeagueController(DB db)
        {
            _db = db;
        }
        // GET: LeagueController
        public ActionResult Index()
        {
            league=_db.League.ToList();
            return View(league);
        }

        // GET: LeagueController/Details/5
        public ActionResult Details(int id)
        {
            var league = _db.League.Where(x => x.LeagueId.Equals(id)).SingleOrDefault();
            return View(league);
        }

        // GET: LeagueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeagueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(League newLeague)
        {
            _db.League.Add(newLeague);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: LeagueController/Edit/5
        public ActionResult Edit(int id)
        {
            var league1 = _db.League.Find(id);
            return View(league1);
        }

        // POST: LeagueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(League leagueNewData)
        {
            try
            {
                var league1=_db.League.Find(leagueNewData.LeagueId);
                if(league1!=null)
                {
                    league1.LeagueId = leagueNewData.LeagueId;  
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

        // GET: LeagueController/Delete/5
        public ActionResult Delete(int id)
        {
            var league1= _db.League.Find(id);
            return View(league1);
        }

        // POST: LeagueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var league1=_db.League.Find(id);
                if (league1!=null)
                {
                    _db.League.Remove(league1);
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
