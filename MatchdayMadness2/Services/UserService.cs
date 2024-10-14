// Services/UserService.cs

namespace MatchdayMadness2.Services;
using MatchdayMadness2.Models;
using MatchdayMadness2.Services; // Adjust the namespace according to your project
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private static DB _db;

    public UserService(DB db)
    {
        _db = db;
    }

    public async Task<(bool IsSuccess, string ErrorMessage)> ValidateUser(string username, string password)
    {
        var user = await _db.Users.SingleOrDefaultAsync(u => u.username == username);

        if (user == null)
        {
            return (false, "User not found");
        }

        // Implement your password verification logic here
        if (!VerifyPassword(password, user.password)) // Replace with actual password verification logic
        {
            return (false, "Invalid password");
        }

        return (true, null);
    }

    private bool VerifyPassword(string password, string storedPassword)
    {
        // Implement your password verification logic here (e.g., hash comparison)
        return password == storedPassword; // This is just a placeholder
    }
}