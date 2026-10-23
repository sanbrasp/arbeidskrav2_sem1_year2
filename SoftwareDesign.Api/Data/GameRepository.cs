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
}