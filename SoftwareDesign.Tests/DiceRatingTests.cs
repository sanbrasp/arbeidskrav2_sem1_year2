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
}