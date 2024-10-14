namespace MatchdayMadness2.Services;

public interface IUserService
{
    Task<(bool IsSuccess, string ErrorMessage)> ValidateUser(string username, string password);
}
