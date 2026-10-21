using SoftwareDesign.Data;
using SoftwareDesign.Models;
using SoftwareDesign.Services;

namespace SoftwareDesign.Tests;

public class GameNightStateTests
{
    private readonly GameRepository _repo; 
    private readonly GameNightState _state;
    private readonly BoardGame _game;
    
    public GameNightStateTests()
    {
        _repo = new GameRepository();
        _state = new GameNightState();
        _game = _repo.RegisterNewBoardGame("Test game", 1, 5, "test category", "just a test", 30);
    }
    
    
    [Fact]
    public void AddToGameNight_ShowsOneGameInList()
    {
        // Arrange
        // In shared constructor

        // Act
        _state.AddToGameNight(_game);
        var numberOfGames = _state.NumberOfGames;

        // Assert
        Assert.Equal(1, numberOfGames);
        Assert.True(_state.IsGameInGameNightList(_game.Id));
    }

    [Fact]
    public void AddToGameNight_AddingDuplicateGame_IsIgnored()
    {
        // Arrange
        // In shared constructor

        // Act
        _state.AddToGameNight(_game);
        _state.AddToGameNight(_game);
        var numberOfGames = _state.NumberOfGames;

        // Assert
        Assert.Equal(1, numberOfGames);
    }

    [Fact]
    public void AddToGameNight_TwoObjectsWithSameId_FirstIsAdded()
    {
        // Arrange
        var game1 = new BoardGame(
            "Duplicate ID test game", 1, 5, "test category", "just a test", 20) {Id = _game.Id};
        
        // Act
        _state.AddToGameNight(_game);
        _state.AddToGameNight(game1);

        // Assert
        Assert.Equal(1, _state.NumberOfGames);
        Assert.Equal("Test game", _state.GetGameNightGames()[0].Name);
    }

    [Fact]
    public void RemoveFromGameNight_EmptiesList()
    {
        // Arrange
        _state.AddToGameNight(_game);

        // Act
        _state.RemoveFromGameNight(_game);
        var numberOfGames = _state.NumberOfGames;
        
        // Assert
        Assert.Equal(0, numberOfGames);
        Assert.False(_state.IsGameInGameNightList(_game.Id));
    }

    [Fact]
    public void TotalPlaytime_ThreeGames_EqualsTheSumOfThree()
    {
        // Arrange
        var game2 = _repo.RegisterNewBoardGame(
            "test 2", 2, 4, "test category", "just a test", 20);
        var game3 = _repo.RegisterNewBoardGame("test 3", 3, 6, "test category", "just a test", 30);
        _state.AddToGameNight(_game);
        _state.AddToGameNight(game2);
        _state.AddToGameNight(game3);
        
        // Act
        var totalPlayTime = _state.TotalPlaytime;
        
        // Assert
        Assert.Equal(80, totalPlayTime); // 30 + 20 + 30
    }

    [Fact]
    public void TotalPlaytime_EmptyList_EqualsZero()
    {
        // Arrange
        // In the shared constructor

        // Act
        var result = _state.TotalPlaytime;
        
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void IsGameInGameNightList_FalseWhenNotAdded()
    {
        // Arrange
        // In the shared constructor
        
        // Act
        var result = _state.IsGameInGameNightList(_game.Id);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void OnChange_IsRaisedOnce_WhenGameIsAdded()
    {
        // Arrange
        int counter = 0;
        _state.OnChange += () => counter++;

        // Act
        _state.AddToGameNight(_game);

        // Assert
        Assert.Equal(1, counter);
    }

    [Fact]
    public void OnChange_IsRaisedOnce_OnDuplicateAdd()
    {
        // Arrange
        int counter = 0;
        _state.OnChange += () => counter++;

        // Act
        _state.AddToGameNight(_game);
        _state.AddToGameNight(_game);

        // Assert
        Assert.Equal(1, counter);
    }

    [Fact]
    public void OnChange_RemovingGameNotInList_DoesNotRaiseOnChange()
    {
        // Arrange
        int counter = 0;
        _state.OnChange += () => counter++;

        // Act
        _state.RemoveFromGameNight(_game);

        // Assert
        Assert.Equal(0, counter);
    }
}