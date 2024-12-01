using MatchdayMadness.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

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
        public async Task<ActionResult> Index()
        {
            try
            {

                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://localhost:7276/api/PlayersControllerAPI/GetPlayer");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var players = JsonConvert.DeserializeObject<List<Players>>(jsonString);
                    return View(players);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        // GET: PlayersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync($"https://localhost:7276/api/PlayersControllerAPI/GetPlayerById?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var players = JsonConvert.DeserializeObject<Players>(jsonString);
                    return View(players);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayersController/Create
        public ActionResult Create()
        {
            var teams = _db.Teams.ToList();
            var teamsSelectList = new SelectList(teams, "id", "Name");
            ViewBag.teams = teamsSelectList;
            return View();
        }

        // POST: PlayersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Players newPlayer)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:7276/api/PlayersControllerAPI/CreatePlayer", newPlayer);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var players = JsonConvert.DeserializeObject<Players>(jsonString);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7276/api/PlayersControllerAPI/GetPlayerById/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var players = JsonConvert.DeserializeObject<Players>(jsonString);
                var player1 = _db.Players.Find(id);
                var teams = _db.Teams.ToList();
                var teamsSelectList = new SelectList(teams, "id", "Name", player1.Teamsid);
                ViewBag.teams = teamsSelectList;
                return View(player1);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: PlayersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Players playersNewData)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.PutAsJsonAsync("https://localhost:7276/api/PlayersControllerAPI/UpdatePlayer", playersNewData);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var players = JsonConvert.DeserializeObject<Players>(jsonString);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: PlayersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7276/api/PlayersControllerAPI/GetPlayerById/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var players = JsonConvert.DeserializeObject<Players>(jsonString);
                var player1 = _db.Players.Find(id);
                return View(player1);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: PlayersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExecuteDelete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = client.DeleteAsync($"https://localhost:7276/api/PlayersControllerAPI/DeletePlayer/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
