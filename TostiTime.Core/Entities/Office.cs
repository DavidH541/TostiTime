namespace TostiTime.Core.Entities;

public class Office : EntityBase
{
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string CityCode { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public List<Person> Persons { get; set; } = new();
    public int NumberOfPersons => Persons.Count;
    public List<Iron> Irons { get; set; } = new();
    public int NumberOfIrons => Irons.Count;
}
