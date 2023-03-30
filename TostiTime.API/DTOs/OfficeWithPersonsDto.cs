namespace TostiTime.API.DTOs;

public class OfficeWithPersonsDto
{
    public int Id { get; set; }
    public string Country { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string CityCode { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public int NumberOfPersons => Persons.Count;
    public List<PersonWithoutReservationsDto> Persons { get; init; } = new();

}