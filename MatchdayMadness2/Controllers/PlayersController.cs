using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace MatchdayMadness2.Controllers
{
   
    public class PlayersController : Controller
    {
        private static DB _db;
        public PlayersController(DB db)
        {
            _db = db;
        }
        private static List<Players> players = new List<Players>();
        // GET: PlayersController
        public ActionResult Index()
        {           
            players = _db.Players.ToList();
            return View(players);

        }
        // GET: PlayersController/Details/5
        public ActionResult Details(int id)
        {
            var p1 = _db.Players.Include(x=>x.Teams).Where(x => x.ID.Equals(id)).SingleOrDefault();
            return View(p1);
        }

        // GET: PlayersController/Create
        public ActionResult Create()
        {
            var teams = _db.Teams.ToList();
            var teamsSelectList = new SelectList(teams,"id","Name");
            ViewBag.teams = teamsSelectList;
            return View();
        }

        // POST: PlayersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Players newPlayer)
        {
            _db.Players.Add(newPlayer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PlayersController/Edit/5
        public ActionResult Edit(int id)
        {
            var player1 = _db.Players.Find(id);
            var teams = _db.Teams.ToList();
            var teamsSelectList = new SelectList(teams, "id", "Name", player1.Teamsid);
            ViewBag.teams = teamsSelectList;
            return View(player1);
        }

        // POST: PlayersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Players playersNewData)
        {
            try
            {

                var player1 = _db.Players.Find( playersNewData.ID);
                
                player1.Name = playersNewData.Name;
                player1.Age = playersNewData.Age; 
                player1.Position = playersNewData.Position;
                player1.Teamsid = playersNewData.Teamsid;   
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
               
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayersController/Delete/5
        public ActionResult Delete(int id)
        {
            var player1 = _db.Players.Find(id);
            return View(player1);
        }

        // POST: PlayersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id )
        {
            try
            {
                var player1 = _db.Players.Find(id);
                _db.Players.Remove(player1);
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
