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
    private static IResult GetAllGames()
    {
        throw new NotImplementedException();
    }
    
    private static IResult GetGameById(int id)
    {
        throw new NotImplementedException();
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