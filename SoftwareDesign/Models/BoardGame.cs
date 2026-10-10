namespace SoftwareDesign.Models;

public class BoardGame
{
    public int Id { get; init; }
    public string Name { get; private set; } = "";
    public int MinPlayers { get; private set; }
    public int MaxPlayers { get; private set; }
    public int PlayTimeMinutes { get; private set; }
    public string Category { get; private set; } = "";
    public int Rating { get; private set; }
    public string Description { get; private set; } = "";


    public BoardGame(string name, int minPlayers, int maxPlayers, string category, string description)
    {
        Id += 1;
        Name = name;
        MinPlayers = minPlayers;
        MaxPlayers = maxPlayers;
        Category = category;
        Description = description;
    }
    
    public void SetRating(int rating)
    {
        Rating = rating;
    }
}