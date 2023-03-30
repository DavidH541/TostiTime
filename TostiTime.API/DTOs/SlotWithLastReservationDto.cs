namespace TostiTime.API.DTOs;

public class SlotWithLastReservationDto
{
    public int Id { get; init; }
    public string? SlotName { get; init; }
    public ReservationDto LastReservation { get; init; } = new();
}
