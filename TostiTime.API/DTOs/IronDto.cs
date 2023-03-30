using TostiTime.Core.Entities;

namespace TostiTime.API.DTOs;

public record IronDto
{
    public int Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public int NumberOfSlots => Slots.Count;
    public List<SlotWithLastReservationDto> Slots { get; init; } = new();
}
