using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Mvc;


namespace MatchdayMadness2.Controllers
{
    public class TableController : Controller
    {
        private static List<Table> table = new List<Table>();
        // GET: TableController
        public ActionResult Index()
        {
            return View(table);
        }

        // GET: TableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table newTable)
        {
            {
                table.Add(newTable);
                return RedirectToAction("Index");
            }
        }

        // GET: TableController/Edit/5
        public ActionResult Edit(int id)
        {
            var table1 = table.Find(x => x.id == id);
            return View(table1);
        }

        // POST: TableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Table tableNewData)
        {
            try
            {
                var table1 = table.Find(x => x.id == tableNewData.id);
                if (table1 != null)
                {
                    table1.LeagueName = tableNewData.LeagueName;
                    table1.Teamsid = tableNewData.Teamsid;
                    table1.Standings = tableNewData.Standings;
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

        // GET: TableController/Delete/5
        public ActionResult Delete(int id)
        {
            var table1 = table.Find(x => x.id == id);
            return View(table1);
        }

        // POST: TableController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var table1 = table.Find(x => x.id == id);
                if (table1 != null)
                    table.Remove(table1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
