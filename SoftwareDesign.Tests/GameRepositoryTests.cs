using SoftwareDesign.Data;
using SoftwareDesign.Models;

namespace SoftwareDesign.Tests;

public class GameRepositoryTests
{
    [Fact]
    public void GetAllGames_GameSeeding_IdsFromOneAndUp()
    {
        // Arrange
        GameRepository gameRepo = new GameRepository();
        
        // Act
        var gameIds = gameRepo.GetAllGames().Select(game => game.Id).ToList();

        // Assert
        Assert.Equal(Enumerable.Range(1, gameIds.Count), gameIds);
    }

    [Fact]
    public void RegisterNewBoardGame_NewGame_GetsNextId()
    {
        // Arrange
        GameRepository gameRepo = new GameRepository();
        var gameCount = gameRepo.GetAllGames().Count;

        // Act
        var newGame = gameRepo.RegisterNewBoardGame("TestGame", 1, 12, "test", "test", 10);

        // Assert
        Assert.Equal((gameCount + 1), newGame.Id);
    }

    [Fact]
    public void GetGameById_ExistingId_ReturnsGame()
    {
        // Arrange
        GameRepository gameRepo = new GameRepository();

        // Act
        BoardGame? game = gameRepo.GetGameById(1);

        // Assert
        Assert.NotNull(game);
        Assert.Equal(1,game.Id);
    }

    [Fact]
    public void GetGameById_NonExistingId_ReturnsNull()
    {
        // Arrange
        GameRepository gameRepo = new GameRepository();

        // Act
        BoardGame? game = gameRepo.GetGameById(999);

        // Assert
        Assert.Null(game);
    }
}