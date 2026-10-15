using SoftwareDesign.Models;

namespace SoftwareDesign.Services;

internal class GameFilterService
{
    public IReadOnlyList<BoardGame> Filter(IEnumerable<BoardGame> boardGames, string searchInput)
    {
        var searchResult = boardGames.Where(g => g.Name.ToLower().Contains(searchInput.ToLower()));
        
        return searchResult.ToList();
    }

    public IReadOnlyList<BoardGame> FilterByNumberOfPlayers(IEnumerable<BoardGame> boardGames, int numberOfPlayers)
    {
        var numberResult = boardGames.Where(n => n.MinPlayers <= numberOfPlayers && n.MaxPlayers >= numberOfPlayers);
        
        return numberResult.ToList();
    }

    public int MaxAmountOfPlayers(IEnumerable<BoardGame> boardGames)
    {
        int empty = 0;
        if (!boardGames.Any())
        {
            return empty;
        }
        
        return boardGames.Max(g => g.MaxPlayers);
    }
}