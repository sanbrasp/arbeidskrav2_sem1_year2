using SoftwareDesign.Models;
using SoftwareDesign.Services;

namespace SoftwareDesign.Tests;

public class GameRandomizerTests
{
    [Fact]
    public void GetRandomGame_EmptyList_ReturnsNull()
    {
        // Arrange
        List<BoardGame> emptyList = new List<BoardGame>();
        GameRandomizer randomizer = new GameRandomizer();

        // Act
        var result = randomizer.GetRandomGame(emptyList);
        
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetRandomGame_OneGame_ReturnsThatGame()
    {
        // Arrange
        List<BoardGame> singleItemList = new List<BoardGame>();
        BoardGame game = new BoardGame("Single Board Game", 1, 2, "Test", "Test", 10);
        singleItemList.Add(game);
        GameRandomizer randomizer = new GameRandomizer();

        // Act
        var result = randomizer.GetRandomGame(singleItemList);
        
        // Assert
        Assert.Equal(result, game);
    }
}