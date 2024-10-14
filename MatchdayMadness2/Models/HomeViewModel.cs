namespace MatchdayMadness2.Models;

public class HomeViewModel
{
    public List<Matches> Match { get; set; }  // Holds match data
    public User? LoggedInUser { get; set; }  // Holds user info if logged in
}