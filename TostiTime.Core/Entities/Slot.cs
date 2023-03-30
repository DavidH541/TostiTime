namespace TostiTime.Core.Entities;

public class Slot : EntityBase
{
    public Iron? Iron { get; set; }
    public int IronId { get; set; }
    public string SlotName { get; set; } = string.Empty;
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public Reservation? LastReservation => Reservations.OrderByDescending(e => e.OccupiedUntil).FirstOrDefault();

    public void AddReservation(Person person, DateTime occupiedSince)
    {
        Reservations.Add(new Reservation(this, person, occupiedSince, DateTime.MaxValue));
    }
}
    