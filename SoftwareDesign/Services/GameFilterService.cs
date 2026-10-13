using SoftwareDesign.Models;

namespace SoftwareDesign.Services;

internal class GameFilterService
{
    public IEnumerable<BoardGame> Filter(IEnumerable<BoardGame> boardGames, string searchInput)
    {
        var searchResult = boardGames.Where(g => g.Name.ToLower().Contains(searchInput.ToLower()));
        
        return searchResult;
    }
}