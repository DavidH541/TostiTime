using System.Linq.Expressions;
using TostiTime.Core.Entities;

namespace TostiTime.Data.Specifications;

public class OfficeSpec : BaseSpecification<Office>
{
    public OfficeSpec() 
        : base(e => true)
    { }
}
