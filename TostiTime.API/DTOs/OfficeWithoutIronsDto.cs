using TostiTime.Core.Entities;

namespace TostiTime.API.DTOs;

public record OfficeWithoutIronsDto
{
    public int Id { get; set; }
    public string Country { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string CityCode { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
}
