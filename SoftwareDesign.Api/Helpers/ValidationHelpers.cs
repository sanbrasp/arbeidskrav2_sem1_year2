using SoftwareDesign.Api.Models;

namespace SoftwareDesign.Api.Validation;

internal static class ValidationHelpers
{
    public static Dictionary<string, string[]> ValidateRequest(GameRequest request)
    {
        List<int> validRatings = [0, 1, 2, 3, 4, 5, 6];
        var errors = new Dictionary<string, string[]>();
        
        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name", ["Name is required"]);
        
        if (request.MinPlayers <= 0)
            errors.Add("MinPlayers", ["MinPlayers must be at least 1"]);
        
        if (request.MaxPlayers < request.MinPlayers)
            errors.Add("MaxPlayers", ["MaxPlayers must be at least 1"]);
        
        if (!validRatings.Contains(request.Rating))
            errors.Add("Rating", ["Rating must be between 0 and 6"]);
        
        if (request.PlaytimeMinutes <= 0)
            errors.Add("PlaytimeMinutes", ["PlaytimeMinutes must be greater than 0"]);
        
        return errors;
    }
}