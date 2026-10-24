using SoftwareDesign.Api.Data;
using SoftwareDesign.Api.Models;

namespace SoftwareDesign.Api.Endpoints;

internal static class GameEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/api/games");

        group.MapGet("/", GetAllGames);

        group.MapGet("/{id:int}", GetGameById);

        group.MapPost("/", CreateGame);
        
        group.MapPut("/{id:int}", UpdateGame);
        
        group.MapDelete("/{id:int}", DeleteGame);
    }
    
    
    
    
    // Handlers
    private static IResult GetAllGames(GameRepository gameRepo)
    {
        return TypedResults.Ok(gameRepo.GetAllGames());
    }
    
    private static IResult GetGameById(int id, GameRepository gameRepo)
    {
        var game = gameRepo.GetGameById(id);
        
        if (game is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(game);
    }

    private static IResult CreateGame(GameRequest request)
    {
        throw new NotImplementedException();
    }

    private static IResult UpdateGame(int id, GameRequest request)
    {
        throw new NotImplementedException();
    }

    private static IResult DeleteGame(int id)
    {
        throw new NotImplementedException();
    }
}