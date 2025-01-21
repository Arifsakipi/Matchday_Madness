using MatchdayMadness.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Net.Http.Json;

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
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5156/api/TeamsControllerAPI/GetTeams\r\n");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<List<Teams>>(jsonString);
                return View(teams);
            }
            else
            {
                return View();
            }
        }

        // GET: TeamsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("http://localhost:5156/api/TeamsControllerAPI/GetTeamById?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                var teams = JsonConvert.DeserializeObject<Teams>(jsonString);
                return PartialView("_DetailsPartial", teams);
            }
            else
            {
                return View();
            }
        }

        // GET: TeamsController/Create
        public ActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        // POST: TeamsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Teams newTeam)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:5156/api/TeamsControllerAPI/CreateTeam\r\n", newTeam);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<Teams>(jsonString);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newTeam);
            }
        }

        // GET: TeamsController/Edit/5
        public ActionResult Edit(int id)
        {
            var team1 = _db.Teams.Find(id);
            return PartialView("_EditPartial", team1);
        }

        // POST: TeamsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Teams teamsNewData)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync("http://localhost:5156/api/TeamsControllerAPI/UpdateTeam\r\n", teamsNewData);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<Teams>(jsonString);
                return RedirectToAction("Index");
            }
            else
            {
                return View(teamsNewData);
            }
        }

        // GET: TeamsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:5156/api/TeamsControllerAPI/GetTeamById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<Teams>(jsonString);
                var team1 = _db.Teams.Find(id);
                return PartialView("_DeletePartial_Teams", teams);
            }
            else
            {
                return View();
            }
        }

        // POST: TeamsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExecuteDelete(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync($"http://localhost:5156/api/TeamsControllerAPI/DeleteTeam?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            {
                return View();
            }
        }
    }
}
