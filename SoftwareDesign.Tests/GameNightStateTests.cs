using SoftwareDesign.Data;
using SoftwareDesign.Services;

namespace SoftwareDesign.Tests;

public class GameNightStateTests
{
    [Fact]
    public void AddGameToGameNight_ShowsOneGameInList()
    {
        // Arrange
        var state = new GameNightState();
        var repo = new GameRepository();
        var game = repo.RegisterNewBoardGame(
            "Test game", 1, 5, "test category", "just a test", 30);

        // Act
        state.AddToGameNight(game);
        var numberOfGames = state.NumberOfGames;

        // Assert
        Assert.Equal(1, numberOfGames);
        Assert.True(state.IsGameInGameNightList(game.Id));
    }
}