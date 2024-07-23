using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;


namespace MatchdayMadness2.Controllers
{
    public class ResultsController : Controller
    {
        private static List< Models.Results> results = new List<Models.Results>();
        // GET: ResultsControllerpublic
        public ActionResult Index()
        {
            return View(results);
        }

        // GET: ResultsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResultsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResultsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Results newResults)
        {          
            {
                results.Add(newResults);
                return RedirectToAction("Index");
            }
        }

        // GET: ResultsController/Edit/5
        public ActionResult Edit(int id)
        {
            var results1 = results.Find(x => x.id == id);
            return View(results1);
        }

        // POST: ResultsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Results resultsNewData)
        {
            try
            {
                var results1 = results.Find(x => x.id == resultsNewData.id);
                if (results1 != null)
                {
                    results1.Details = resultsNewData.Details;
                    results1.Winner = resultsNewData.Winner;
                    results1.Loser = resultsNewData.Loser;
                    results1.Events = resultsNewData.Events;
                }else 
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

        // GET: ResultsController/Delete/5
        public ActionResult Delete(int id)
        {
            var results1 = results.Find(x => x.id == id);
            return View(results1);
        }

        // POST: ResultsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var results1 = results.Find(x => x.id == id);
                if (results1 != null) 
                    results.Remove(results1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
