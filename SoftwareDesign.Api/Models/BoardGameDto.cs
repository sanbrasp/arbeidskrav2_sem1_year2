namespace SoftwareDesign.Api.Models;

internal class BoardGameDto
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public int MinPlayers { get; init; }
    public int MaxPlayers { get; init; }
    public string Category { get; init; } = "";
    public string Description { get; init; } = "";
    public int PlaytimeMinutes { get; init; }
    
}