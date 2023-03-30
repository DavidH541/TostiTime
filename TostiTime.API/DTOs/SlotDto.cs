namespace TostiTime.API.DTOs;

public record SlotDto
{
    public int Id { get; init; }
    public string? SlotName { get; init; }
    public List<ReservationDto> Reservations { get; init; } = new();
}