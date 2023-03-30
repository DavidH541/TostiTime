namespace TostiTime.API.DTOs;

public class PersonDto
{
    public int Id { get; set; }
    public string? FirstName { get; init; }
    public int OfficeId { get; init; }
    public int NumberOfReservations => Reservations.Count;
    public List<ReservationDto> Reservations { get; init; } = new();
}
