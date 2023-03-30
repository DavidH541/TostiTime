using TostiTime.Core.Entities;

namespace TostiTime.Data.Specifications;

public class OfficeWithPersonsSpec : BaseSpecification<Office>
{
    public OfficeWithPersonsSpec(int officeId)
        : base(d => d.Id.Equals(officeId))
    {
        AddInclude(d => d.Persons);
    }

    public OfficeWithPersonsSpec(string name)
        : base(d => d.City.Equals(name))
    {
        AddInclude(d => d.Persons);
    }
}
