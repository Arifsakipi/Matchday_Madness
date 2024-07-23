using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness2.Controllers
{
    public class EventsController : Controller
    {
        private static List<Events> events = new List<Events>();
        // GET: EventsController
        public ActionResult Index()
        {
            return View(events);
        }

        // GET: EventsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Events newEvent)
        {          
            {
                events.Add(newEvent);
                return RedirectToAction("Index");
            }
        }

        // GET: EventsController/Edit/5
        public ActionResult Edit(int id)
        {
            var event1 = events.Find(x => x.id == id);  
            return View(event1);
        }

        // POST: EventsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Events eventsNewData)
        {
            try
            {
                var event1 = events.Find(x => x.id == eventsNewData.id);
                if (event1 != null) 
                {
                    event1.Goals = eventsNewData.Goals; 
                    event1.Shots = eventsNewData.Shots;
                    event1.YellowCards = eventsNewData.YellowCards;
                    event1.RedCards = eventsNewData.RedCards;
                    event1.Fouls = eventsNewData.Fouls;
                    event1.Substitutions = eventsNewData.Substitutions;
                    event1.Corners = eventsNewData.Corners;
                    event1.FreeKicks = eventsNewData.FreeKicks;
                    event1.Possession = eventsNewData.Possession;
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

        // GET: EventsController/Delete/5
        public ActionResult Delete(int id)
        {
            var event1 = events.Find(x => x.id == id);
            return View(event1);
        }

        // POST: EventsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var event1 = events.Find(x => x.id == id);
                if (event1 != null) 
                    events.Remove(event1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
