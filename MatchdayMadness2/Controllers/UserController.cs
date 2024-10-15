
using BCrypt.Net;
using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;


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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user1 = _db.Users.Find(id);
            return View(user1);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                if (user != null)
                    _db.Users.Remove(user);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial", new User());
        }

        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _db.Users.SingleOrDefault(u => u.username == username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.password))
            {
                // Sign in the user
                await SignInUser(user);

                // Redirect to home page with user info
                return RedirectToAction("Index", "Home");
            }
            // Handle failure
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SignUpPartial()
        {
            return PartialView("_SignUpPartial", new User());
        }

        [HttpPost]
        public async Task<IActionResult> Signup(string username, string email, string password, string phoneNumber, DateTime dateOfBirth)
        {
            var user = new User
            {
                username = username,
                email = email,
                password = BCrypt.Net.BCrypt.HashPassword(password),
                phoneNumber = phoneNumber,
                dateOfBirth = dateOfBirth
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            // Sign in the user
            await SignInUser(user);

            // Redirect to home page
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.username),
                    new Claim(ClaimTypes.Email, user.email)
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}