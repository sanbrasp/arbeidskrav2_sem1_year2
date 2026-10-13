using SoftwareDesign.Models;

namespace SoftwareDesign.Services;

internal class GameFilterService
{
    public IEnumerable<BoardGame> Filter(IEnumerable<BoardGame> boardGames, string searchInput)
    {
        var searchResult = boardGames.Where(g => g.Name.ToLower().Contains(searchInput.ToLower()));
        
        return searchResult;
    }

    public IEnumerable<BoardGame> FilterByNumberOfPlayers(IEnumerable<BoardGame> boardGames, int numberOfPlayers)
    {
        var numberResult = boardGames.Where(n => n.MinPlayers <= numberOfPlayers && n.MaxPlayers >= numberOfPlayers);
        
        return numberResult;
    }
}