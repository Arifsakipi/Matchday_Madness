using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchdayMadness2.Controllers
{
    public class EventsController : Controller
    {
        private static DB _db;
        public EventsController(DB db)
        {
            _db= db;
        }
        private static List<Events> events= new List<Events>();
        // GET: EventsController
        public ActionResult Index()
        {
            events=_db.Events.ToList();
            return View(events);
        }

        // GET: EventsController/Details/5
        public ActionResult Details(int id)
        {
           var e1=_db.Events.Where(x=>x.id==id).SingleOrDefault();
            return View(e1);    
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
                _db.Events.Add(newEvent);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: EventsController/Edit/5
        public ActionResult Edit(int id)
        {
            var event1 = _db.Events.Find(id);  
            return View(event1);
        }

        // POST: EventsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Events eventsNewData)
        {
            try
            {
                 var event1=_db.Events.Find(eventsNewData.id);  
                
                    event1.Goals = eventsNewData.Goals; 
                    event1.Shots = eventsNewData.Shots;
                    event1.YellowCards = eventsNewData.YellowCards;
                    event1.RedCards = eventsNewData.RedCards;
                    event1.Fouls = eventsNewData.Fouls;
                    event1.Substitutions = eventsNewData.Substitutions;
                    event1.Corners = eventsNewData.Corners;
                    event1.FreeKicks = eventsNewData.FreeKicks;
                    event1.Possession = eventsNewData.Possession;
                 _db.SaveChanges(); 
                
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
            var event1 = _db.Events.Find(id);
            return View(event1);
        }

        // POST: EventsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var event1 = _db.Events.Find(id);
                _db.Events.Remove(event1);
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
