using SoftwareDesign.Models;
using SoftwareDesign.Services;

namespace SoftwareDesign.Tests;

public class GameFilterServiceTests
{
    private readonly GameFilterService _gameFilterService;
    private readonly List<BoardGame> _testList = new List<BoardGame>();
    public GameFilterServiceTests()
    {
        _gameFilterService = new GameFilterService();
        _testList.Add(new BoardGame("Monkeys", 6, 8, "Adventure", "test game"));
        _testList.Add(new BoardGame("Cards", 2, 4, "Card", "test game"));
    }
    
    
    [Fact]
    public void Filter_FindsExistingGame_LowerAndUpperCase()
    {
        // Arrange
        // In the shared constructor
        
        // Act
        var lowerResult = _gameFilterService.Filter(_testList, "car");
        var upperResult = _gameFilterService.Filter(_testList, "MON");

        // Assert
        Assert.Single(lowerResult);
        Assert.Single(upperResult);
        Assert.Equal("Cards", lowerResult[0].Name);
        Assert.Equal("Monkeys", upperResult[0].Name);
    }
    
    [Fact]
    public void Filter_NoMatch_ReturnsEmptyList()
    {
        // Arrange
        // In the shared constructor

        // Act
        var noMatchSearch = _gameFilterService.Filter(_testList, "People");

        // Assert
        Assert.Empty(noMatchSearch);
    }
    
    [Fact]
    public void Filter_CombinedSearchAndFilter_ReturnsCorrectNumberOfHits()
    {
        // Arrange
        // In the shared constructor

        // Act
        var searchFilterResult = _gameFilterService.Filter(_testList, "s");
        var combinedResult = _gameFilterService.FilterByNumberOfPlayers(searchFilterResult, 8);

        // Assert
        Assert.Equal(2, searchFilterResult.Count);
        Assert.Single(combinedResult);
        Assert.Equal("Monkeys", combinedResult[0].Name);
    }

    [Fact]
    public void Filter_EmptyingSearch_ReturnsAllGames()
    {
        // Arrange
        // In the shared constructor

        // Act
        var emptySearchFieldResult = _gameFilterService.Filter(_testList, "");

        // Assert
        Assert.Equal(_testList, emptySearchFieldResult);
    }
    
    [Fact]
    public void FilterByNumberOfPlayers_UpholdsFilteringRules_ShowsCorrectGames()
    {
        // Arrange
        // In the shared constructor

        // Act
        var resultForTwoPlayers = _gameFilterService.FilterByNumberOfPlayers(_testList, 2);
        var resultForFourPlayers = _gameFilterService.FilterByNumberOfPlayers(_testList, 4);
        var resultForOnePlayer = _gameFilterService.FilterByNumberOfPlayers(_testList, 1);
        var resultForFivePlayers = _gameFilterService.FilterByNumberOfPlayers(_testList, 5);
        
        // Assert
        Assert.Single(resultForTwoPlayers);
        Assert.Single(resultForFourPlayers);
        Assert.Empty(resultForOnePlayer);
        Assert.Empty(resultForFivePlayers);
        Assert.Equal("Cards", resultForTwoPlayers[0].Name);
    }
    
    [Fact]
    public void MaxAmountOfPlayers_EmptyList_ReturnsZero()
    {
        // Arrange
        var emptyList = new List<BoardGame>();

        // Act
        var emptyListResult = _gameFilterService.MaxAmountOfPlayers(emptyList);

        // Assert
        Assert.Equal(0, emptyListResult);
    }

    [Fact]
    public void MaxAmountOfPlayers_ReturnsCorrectAmount()
    {
        // Arrange
        // In the shared constructor

        // Act
        var result = _gameFilterService.MaxAmountOfPlayers(_testList);

        // Assert
        Assert.Equal(8, result);
    }
}