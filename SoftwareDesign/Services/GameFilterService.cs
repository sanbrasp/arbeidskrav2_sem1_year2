using SoftwareDesign.Models;

namespace SoftwareDesign.Services;

internal class GameFilterService
{ 
    public IReadOnlyList<BoardGame> Filter(IReadOnlyList<BoardGame> boardGames, string searchInput)
    {
        var searchResult = boardGames.Where(g => g.Name.ToLower().Contains(searchInput.ToLower()));
        
        return searchResult.ToList();
    }

    public IReadOnlyList<BoardGame> FilterByNumberOfPlayers(IReadOnlyList<BoardGame> boardGames, int numberOfPlayers)
    {
        var numberResult = boardGames.Where(n => n.MinPlayers <= numberOfPlayers && n.MaxPlayers >= numberOfPlayers);
        
        return numberResult.ToList();
    }

    public int MaxAmountOfPlayers(IReadOnlyList<BoardGame> boardGames)
    {
        if (!boardGames.Any())
        {
            return 0;
        }
        
        return boardGames.Max(g => g.MaxPlayers);
    }
}