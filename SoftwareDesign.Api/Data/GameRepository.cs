using SoftwareDesign.Api.Models;

namespace SoftwareDesign.Api.Data;

internal class GameRepository
{
    private readonly List<GameResponse> _boardGames = new List<GameResponse>();
    private int _nextId = 1;

    internal IReadOnlyList<GameResponse> GetAllGames() // GET
    {
        return _boardGames;
    }

    internal GameResponse? GetGameById(int id) => _boardGames.FirstOrDefault(g => g.Id == id); // GET

    internal GameResponse RegisterNewBoardGame(GameRequest request)
    {
        var newGameId = _nextId++;
        var newGame = new GameResponse()
        {
            Id = newGameId, Name = request.Name, MinPlayers = request.MinPlayers, MaxPlayers = request.MaxPlayers,
            Category = request.Category, Rating = request.Rating, Description = request.Description,
            PlaytimeMinutes = request.PlaytimeMinutes
        };
        _boardGames.Add(newGame);

        return newGame;
    }

    internal GameResponse? UpdateGame(int id, GameRequest request)
    {
        var oldGameIndex = _boardGames.FindIndex(g => g.Id == id);

        if (oldGameIndex == -1)
            return null;

        var gameUpdate = new GameResponse()
        {
            Id = id, Name = request.Name, MinPlayers = request.MinPlayers, MaxPlayers = request.MaxPlayers,
            Category = request.Category, Rating = request.Rating, Description = request.Description,
            PlaytimeMinutes = request.PlaytimeMinutes
        };

        _boardGames[oldGameIndex] = gameUpdate;

        return gameUpdate;
    }

    internal bool DeleteGame(int id)
    {
        var removedCount = _boardGames.RemoveAll(g => g.Id == id);

        return removedCount > 0;
    }


    /// <summary>
    /// Seed constructor for SoftwareDesign.Api/GameRepository
    /// </summary>
    public GameRepository()
    {
        SeedGame("Wyrmspan", 1, 5, "Strategy",
            "You are an amateur dracologist in the world of Wyrmspan, where dragons roam.", 120);
        
        SeedGame("Wingspan", 1, 5, "Engine-building", 
            "Attract birds to your reserve and chain their abilities together.", 120);
        
        SeedGame("Gloomhaven", 1, 4, "Adventure", 
            "A cooperative fantasy campaign driven by hands of tactical cards", 60);
        
        SeedGame("Pandemic", 2, 4, "Co-op", 
            "Specialists race to cure four diseases before outbreaks spread.", 60);
        
        SeedGame("Catan", 3, 4, "Strategy", 
            "Settle an island, trade resources, and race to ten points.", 45);
        
        SeedGame("Ticket to Ride", 2, 5, "Family", 
            "Collect train cards and claim routes across the map.", 45);
        
        SeedGame("Exploding Kittens", 2, 5, "Card", 
            "Draw cards and hope the next one isn't an exploding kitten.", 60);
        
        SeedGame("Codenames", 4, 8, "Word", 
            "Two teams of spies guess secret words from one-word clues.", 120);
        
        SeedGame("Sushi Go Party!", 2, 8, "Card drafting", 
            "Pick a card, pass the rest, and build the best sushi meal.", 30);
        
        SeedGame("One Night Ultimate Werewolf", 3, 10, "Social deduction", 
            "One night, hidden roles, and ten minutes to find the werewolf.", 120);
        
        SeedGame("Dixit", 3, 6, "Storytelling", 
            "Give clues to pictures that some, but not all, players should guess.", 120);
    }

    
    private void SeedGame(string name, int minPlayers, int maxPlayers, string category, string description,
        int playtimeMinutes)
    {
        var request = new GameRequest()
        {
            Name = name, MinPlayers = minPlayers, MaxPlayers = maxPlayers, Category = category,
            Description = description, PlaytimeMinutes = playtimeMinutes
        };
        RegisterNewBoardGame(request);
    }
}