using SoftwareDesign.Models;

namespace SoftwareDesign.Services;

internal class GameNightState
{
    internal IReadOnlyList<BoardGame> _addedToGameNight = new List<BoardGame>();

    internal IReadOnlyList<BoardGame> GetGameNightGames()
    {
        return _addedToGameNight;
    }
}