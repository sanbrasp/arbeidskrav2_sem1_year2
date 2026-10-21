using SoftwareDesign.Models;

namespace SoftwareDesign.Tests;

public class BoardGameTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(6)]
    public void SetRating_AcceptsValue_WithinBoundaries(int rating)
    {
        // Arrange
        BoardGame boardGame = new BoardGame("Test", 1, 2, "test", "test", 10);
        
        // Act
        boardGame.SetRating(rating);

        // Assert
        Assert.Equal(rating, boardGame.Rating);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    public void SetRating_DoesNotAcceptValue_OutOfBoundaries(int rating)
    {
        // Arrange
        BoardGame boardGame = new BoardGame("Test", 1, 2, "test", "test", 10);
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => boardGame.SetRating(rating));
    }
}