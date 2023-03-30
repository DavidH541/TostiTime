using System.Linq.Expressions;
using TostiTime.Core.Entities;

namespace TostiTime.Core.Interfaces;

public interface ISpecification<T> where T : EntityBase
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
}