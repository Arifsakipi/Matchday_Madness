using BCrypt.Net;
using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using MatchdayMadness2.Services;


public class AccountController : Controller
{
    private readonly IUserService _userService; 
    private static DB _db;

    public AccountController(IUserService userService, DB db)
    {
        _db = db;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var result = await _userService.ValidateUser(username, password);
        var user = _db.Users.SingleOrDefault(u => u.username == username);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.password))
        {
            // Sign in the user
            await SignInUser(user);

            // Redirect to home page with user info
            return RedirectToAction("Index", "Home");
        }
        // Handle failure
        
        return Json(new { success = false, message = result.ErrorMessage });
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