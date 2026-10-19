using Bunit;
using SoftwareDesign.Components;

namespace SoftwareDesign.Tests;

public class DiceRatingTests : BunitContext
{
    [Fact]
    public void DiceRating_RatingThreeGiven_DieFaceThreeIsHighlighted()
    {
        // Arrange
        var cut = Render<DiceRating>(parameters => parameters.Add(p => p.Value, 3));

        // Act
        var result = cut.Find(".dice-option.selected").TextContent;

        // Assert (expected die face "3")
        Assert.Equal("\u2682", result);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(-1)]
    [InlineData(0)] // is "not rated", acts like other out of bounds, no dice highlighted
    [InlineData(100)]
    public void DiceRating_ValueOutOfRange_NoDieIsHighlighted(int rating)
    {
        // Arrange
        var cut = Render<DiceRating>(parameters => parameters.Add(p => p.Value, rating));

        // Act
        var result = cut.FindAll(".dice-option.selected");

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void DiceRating_ReadOnly_IgnoresClicks()
    {
        // Arrange
        int? received = null;
        var cut = Render<DiceRating>(parameters => parameters
            .Add(p => p.ReadOnly, true)
            .Add(p => p.ValueChanged, value => received = value));

        // Act
        var result = cut.FindAll(".dice-option");
        var one = result[0];
        one.Click();

        // Assert
        Assert.Null(received);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(6)]
    public void DiceRating_NotReadOnly_ClickingADieFace_ReportsTheCorrectRating(int rating)
    {
        // Arrange
        int? received = null;
        var cut = Render<DiceRating>(parameters => parameters
            .Add(p => p.ReadOnly, false)
            .Add(p => p.ValueChanged, value => received = value));

        // Act
        var result = cut.FindAll(".dice-option");
        var die = result[rating - 1];
        die.Click();

        // Assert
        Assert.Equal(rating, received);
    }
}