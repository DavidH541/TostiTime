using TostiTime.Core.Entities;

namespace TostiTime.Data.Specifications;

public class OfficeWithIronsWithSlotsSpec : BaseSpecification<Office>
{
    public OfficeWithIronsWithSlotsSpec(int id)
        : base(d => d.Id == id)
    {
        AddInclude("Irons.Slots.Reservations");
    }

    public OfficeWithIronsWithSlotsSpec(string name)
        : base(d => d.City.Equals(name))
    {
        AddInclude("Irons.Slots.Reservations");
    }
}
