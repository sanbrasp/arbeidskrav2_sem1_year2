using SoftwareDesign.Api.Data;
using SoftwareDesign.Api.Models;
using SoftwareDesign.Api.Validation;

namespace SoftwareDesign.Api.Endpoints;

internal static class GameEndpoints
{
    private const string BasePath = "/api/games";
    
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup(BasePath);

        group.MapGet("/", GetAllGames);

        group.MapGet("/{id:int}", GetGameById);

        group.MapPost("/", CreateGame);
        
        group.MapPut("/{id:int}", UpdateGame);
        
        group.MapDelete("/{id:int}", DeleteGame);
    }
    
    
    
    
    // Handlers
    private static IResult GetAllGames(GameRepository gameRepo) // GET
    {
        return TypedResults.Ok(gameRepo.GetAllGames());
    }
    
    private static IResult GetGameById(int id, GameRepository gameRepo) // GET
    {
        var game = gameRepo.GetGameById(id);
        if (game is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(game);
    }

    private static IResult CreateGame(GameRequest request, GameRepository gameRepo) // POST
    {
        var validation = ValidationHelpers.ValidateRequest(request);
        if (validation.Count > 0)
            return TypedResults.ValidationProblem(validation);
        
        var newGame = gameRepo.RegisterNewBoardGame(request);
        var address = BasePath + "/" + newGame.Id;
        
        return TypedResults.Created(address, newGame); // 201
    }

    private static IResult UpdateGame(int id, GameRequest request, GameRepository gameRepo) // PUT
    {
        var validation = ValidationHelpers.ValidateRequest(request); // 400
        if (validation.Count > 0)
            return TypedResults.ValidationProblem(validation); // 400
        
        var updatedGame = gameRepo.UpdateGame(id, request);
        if (updatedGame is null)
        {
            return TypedResults.NotFound(); // 404
        }
        
        return TypedResults.Ok(updatedGame); // 200
    }

    private static IResult DeleteGame(int id, GameRepository gameRepo) // DELETE
    {
        var deleted = gameRepo.DeleteGame(id);
        if (!deleted)
            return TypedResults.NotFound();
        
        return TypedResults.NoContent();
    }
}