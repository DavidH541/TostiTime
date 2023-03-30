using TostiTime.Core.Entities;

namespace TostiTime.API.DTOs;

public record ReservationDto
{
    public int SlotId { get; set; }
    public int PersonId { get; init; }
    public DateTime OccupiedSince { get; init; }
    public DateTime OccupiedUntil { get; init; }
}