using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MatchdayMadness2.Controllers
{
    public class FavoritesController : Controller
    {
        private static DB _db;
        public FavoritesController(DB db)
        {
            _db = db;
        }
        private static List<Favorites> favorites = new List<Favorites>();
        // GET: FavoritesController
        public ActionResult Index()
        {
            favorites = _db.Favorites
                .Include(x=>x.Teams).Include(x=>x.Players).ToList();

            return View(favorites);
        }

        // GET: FavoritesController/Details/5
        public ActionResult Details(int id)
        {
            var favoriteTeamPlayer = _db.Favorites.Include(x=>x.Teams).Include(x=>x.Players).Where(x => x.id.Equals(id)).SingleOrDefault();
            return View(favoriteTeamPlayer);
        }

        // GET: FavoritesController/Create
        public ActionResult Create()
        {

            ViewBag.Teams = new SelectList(_db.Teams, "id", "Name"); 
            ViewBag.Players = new SelectList(_db.Players, "ID", "Name");
           
            return View(new Favorites());
        }

        // POST: FavoritesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Favorites newFavorite)

        {
            
                _db.Favorites.Add(newFavorite);
                _db.SaveChanges();
                ViewBag.Teams = new SelectList(_db.Teams, "ID", "Name", newFavorite.Teamsid);
                ViewBag.Players = new SelectList(_db.Players, "ID", "Name", newFavorite.PlayersID);


                return RedirectToAction("Index");
            
        }

        // GET: FavoritesController/Edit/5
        public ActionResult Edit(int id)
        {
                var favoriteTeamPlayer = _db.Favorites.Find(id);
                ViewBag.Teams = new SelectList(_db.Teams, "id", "Name");
                ViewBag.Players = new SelectList(_db.Players, "ID", "Name");
            return View(favoriteTeamPlayer);
        }

        // POST: FavoritesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Favorites favoritesNewData)
        {
            try
            {
                var favoriteTeamPlayer = _db.Favorites.Find(favoritesNewData.id);
                ViewBag.Teams = new SelectList(_db.Teams, "ID", "Name", favoritesNewData.id);
                ViewBag.Players = new SelectList(_db.Players, "ID", "Name", favoritesNewData.id);
                if (favoriteTeamPlayer != null)
                {
                    favoriteTeamPlayer.Teamsid = favoritesNewData.Teamsid;
                    favoriteTeamPlayer.PlayersID = favoritesNewData.PlayersID;
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

        // GET: FavoritesController/Delete/5
        public ActionResult Delete(int id)
        {
            var favoriteTeamPlayer = _db.Favorites.Find(id);
            return View(favoriteTeamPlayer);
        }

        // POST: FavoritesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var favoriteTeamPlayer = _db.Favorites.Find(id);
                if (favoriteTeamPlayer != null)
                    _db.Favorites.Remove(favoriteTeamPlayer);
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
