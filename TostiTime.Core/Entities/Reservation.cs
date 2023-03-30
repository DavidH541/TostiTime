using System.Collections.Generic;

namespace TostiTime.Core.Entities;

public class Reservation
{
    public int SlotId { get; set; }
    public Slot Slot { get; set; }
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
    public DateTime OccupiedSince { get; set; }
    public DateTime OccupiedUntil { get; set; }

    public Reservation() { }

    public Reservation(Slot slot, Person person, DateTime occupiedSince, DateTime occupiedUntil)
    {
        SlotId = slot.Id;
        Slot = slot;
        PersonId = person.Id;
        Person = person;
        OccupiedSince = occupiedSince;
        OccupiedUntil = occupiedUntil;
    }
}