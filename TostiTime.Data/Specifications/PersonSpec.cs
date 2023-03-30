using System.Linq.Expressions;
using TostiTime.Core.Entities;

namespace TostiTime.Data.Specifications;

public class PersonSpec : BaseSpecification<Person>
{
    public PersonSpec()
        : base(e => true)
    {
        AddInclude(s => s.Reservations);
    }

    public PersonSpec(int id)
        : base(e => e.Id == id)
    {
        AddInclude(s => s.Reservations);
    }

    public PersonSpec(string firstName)
        : base(e => e.FirstName == firstName)
    {
        AddInclude(s => s.Reservations);
    }
}
