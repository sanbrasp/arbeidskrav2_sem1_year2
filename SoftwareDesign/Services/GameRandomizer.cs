using SoftwareDesign.Models;

namespace SoftwareDesign.Services;

internal class GameRandomizer
{
    public BoardGame? GetRandomGame(IReadOnlyList<BoardGame> alreadyFilteredList)
    {
        if (!alreadyFilteredList.Any())
        {
            return null;
        }
        
        var randomNumber = Random.Shared.Next(alreadyFilteredList.Count);

        return alreadyFilteredList[randomNumber];
    }
}