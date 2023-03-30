using TostiTime.Core.Entities;

namespace TostiTime.Data.Specifications;

public class SlotWithLastReservationSpec : BaseSpecification<Slot>
{
    public SlotWithLastReservationSpec(int id)
        : base(e => e.Id == id)
    {
        AddInclude(s => s.Reservations.OrderByDescending(e => e.OccupiedUntil).Take(1));
    }
}
