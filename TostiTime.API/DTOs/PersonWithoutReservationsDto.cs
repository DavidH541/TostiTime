namespace TostiTime.API.DTOs;

public class PersonWithoutReservationsDto
{
    public int Id { get; set; }
    public string? FirstName { get; init; }
    public int OfficeId { get; init; }
}
