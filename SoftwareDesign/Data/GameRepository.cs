using SoftwareDesign.Models;

namespace SoftwareDesign.Data;

internal class GameRepository
{
    private readonly List<BoardGame> _boardGames = new List<BoardGame>();
    private int _nextId = 1;
    
    public IReadOnlyList<BoardGame> GetAllGames()
    {
        return _boardGames;
    }

    public GameRepository()
    {
        RegisterNewBoardGame("Wyrmspan", 1, 5, "Strategy",
            "You are an amateur dracologist in the world of Wyrmspan, where dragons roam.");
        
        RegisterNewBoardGame("Wingspan", 1, 5, "Engine-building", 
            "Attract birds to your reserve and chain their abilities together.");
        
        RegisterNewBoardGame("Gloomhaven", 1, 4, "Adventure", 
            "A cooperative fantasy campaign driven by hands of tactical cards");
        
        RegisterNewBoardGame("Pandemic", 2, 4, "Co-op", 
            "Specialists race to cure four diseases before outbreaks spread.");
        
        RegisterNewBoardGame("Catan", 3, 4, "Strategy", 
            "Settle an island, trade resources, and race to ten points.");
        
        RegisterNewBoardGame("Ticket to Ride", 2, 5, "Family", 
            "Collect train cards and claim routes across the map.");
        
        RegisterNewBoardGame("Exploding Kittens", 2, 5, "Card", 
            "Draw cards and hope the next one isn't an exploding kitten.");
        
        RegisterNewBoardGame("Codenames", 4, 8, "Word", 
            "Two teams of spies guess secret words from one-word clues.");
        
        RegisterNewBoardGame("Sushi Go Party!", 2, 8, "Card drafting", 
            "Pick a card, pass the rest, and build the best sushi meal.");
        
        RegisterNewBoardGame("One Night Ultimate Werewolf", 3, 10, "Social deduction", 
            "One night, hidden roles, and ten minutes to find the werewolf.");
        
        RegisterNewBoardGame("Dixit", 3, 6, "Storytelling", 
            "Give clues to pictures that some, but not all, players should guess.");
    }

    internal BoardGame RegisterNewBoardGame(
        string name, int minPlayers, int maxPlayers, string category, string description)
    {
        var newGameId = _nextId++;
        var newGame = new BoardGame(name, minPlayers, maxPlayers, category, description) { Id = newGameId };
        AddGameToRepository(newGame);
        
        return newGame;
    }

    private void AddGameToRepository(BoardGame game)
    {
        _boardGames.Add(game);
    }

    internal BoardGame? GetGameById(int id) => _boardGames.FirstOrDefault(g => g.Id == id);
}