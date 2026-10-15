using SoftwareDesign.Models;

namespace SoftwareDesign.Data;

internal class GameRepository
{
    private readonly List<BoardGame> _boardGames = new List<BoardGame>();
    
    public IReadOnlyList<BoardGame> GetAllGames()
    {
        return _boardGames;
    }

    public GameRepository()
    {
        _boardGames = new List<BoardGame>
        {
            new("Rune Harbor", 2, 4, "Strategy", "Test game"),
            new("Dice & Dragons", 3, 6, "Adventure", "Test game"),
            new("Tiny Tavern", 2, 2, "Card", "Test game"),
            new("Cat Cafe Chaos", 1, 5, "Party", "Test game"),
            new("Rune Raiders", 4, 8, "Party", "Test game"),
            new("Dungeons and Dragons", 2, 12, "RPG", "The classic"),
            new("Snakes and Ladders", 2, 6, "Party", "Avoid the snakes!"),
            new("Maple Forest", 2, 10, "Adventure", "Test game"),
        };
    }
}