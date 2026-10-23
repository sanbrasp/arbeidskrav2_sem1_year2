namespace SoftwareDesign.Api.Models;

internal class BoardGameDto
{
    internal int Id { get; init; }
    internal string Name { get; init; }
    internal int MinPlayers { get; init; }
    internal int MaxPlayers { get; init; }
    internal string Category { get; init; }
    internal string Description { get; init; }
    internal int PlaytimeMinutes { get; init; }
    
}