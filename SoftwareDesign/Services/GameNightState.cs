using SoftwareDesign.Models;

namespace SoftwareDesign.Services;

internal class GameNightState
{
    private readonly List<BoardGame> _addedToGameNight = new List<BoardGame>();
    public int NumberOfGames => _addedToGameNight.Count;
    public event Action? OnChange; // bell

    public IReadOnlyList<BoardGame> GetGameNightGames()
    {
        return _addedToGameNight;
    }

    internal void AddToGameNight(BoardGame game)
    {
        if (_addedToGameNight.All(x => x.Id != game.Id))
        {
            _addedToGameNight.Add(game);
            OnChange?.Invoke(); // ring the bell!
        }
    }

    internal void RemoveFromGameNight(BoardGame game)
    {
        if (_addedToGameNight.Any(x => x.Id == game.Id))
        {
            _addedToGameNight.RemoveAll(x => x.Id == game.Id);
            OnChange?.Invoke();
        }
    }

    internal bool IsGameInGameNightList(int id)
    {
        return _addedToGameNight.Any(x => x.Id == id);
    }
}