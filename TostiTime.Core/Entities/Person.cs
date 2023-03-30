namespace TostiTime.Core.Entities;

public class Person : EntityBase
{
    public string FirstName { get; set; } = string.Empty;
    public Office? Office { get; set; }
    public int OfficeId { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public int NumberOfReservations => Reservations.Count;
}