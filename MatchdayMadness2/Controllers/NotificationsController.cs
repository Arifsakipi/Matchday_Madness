using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness2.Controllers
{
    public class NotificationsController : Controller
    {
        private static List<Notifications> Notifications = new List<Notifications>();
        // GET: NotificationsController
        public ActionResult Index()
        {
            return View(Notifications);
        }

        // GET: NotificationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotificationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Notifications notifications)
        {
            {
                Notifications.Add(notifications);
                return RedirectToAction("Index");
            }
        }

        // GET: NotificationsController/Edit/5
        public ActionResult Edit(int id)
        {
            var notification = Notifications.Find(x => x.id == id);
            return View(notification);
        }

        // POST: NotificationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Notifications notificationsNewData)
        {
            try
            {
                var notification = Notifications.Find(x => x.id == notificationsNewData.id);
                if (notification != null)
                {
                    notification.Time = notificationsNewData.Time;
                    notification.Content = notificationsNewData.Content;
                    notification.Type = notificationsNewData.Type;
                    notification.IsRead = notificationsNewData.IsRead;
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

        // GET: NotificationsController/Delete/5
        public ActionResult Delete(int id)
        {
            var notification = Notifications.Find(x => x.id == id);
            return View(notification);
        }

        // POST: NotificationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var notification = Notifications.Find(x => x.id == id);
                if (notification != null)
                    Notifications.Remove(notification);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
