using TostiTime.Core.Entities;

namespace TostiTime.API.DTOs;

public record IronWithoutSlotsDto
{
    public int Id { get; set; }
    public string Name { get; init; } = string.Empty;    
}
