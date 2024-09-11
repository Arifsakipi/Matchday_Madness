using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness2.Controllers
{
    public class UserController : Controller
    {
        private static DB _db;
        public UserController(DB db)
        {
            _db = db;
        }
        private static List<User> users = new List<User>();
        // GET: UserController
        public ActionResult Index()
        {
            users = _db.Users.ToList();  
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = _db.Users.Where(x => x.id.Equals(id)).SingleOrDefault();
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User newUser)
        {
            {
                _db.Users.Add(newUser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _db.Users.Find(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User userNewData)
        {
            try
            {
                var user = _db.Users.Find(userNewData.id);
                if (user != null)
                {
                    user.username = userNewData.username;
                    user.email = userNewData.email;
                    user.password = userNewData.password;
                    user.phoneNumber = userNewData.phoneNumber;
                    user.dateOfBirth = userNewData.dateOfBirth;
                    _db.SaveChanges();
                } else
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _db.Users.Find(id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id) 
        {
            try
            {
                var user = _db.Users.Find(id);
                if(user!=null)
                    _db.Users.Remove(user);
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
