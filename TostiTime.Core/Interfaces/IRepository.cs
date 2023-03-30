using TostiTime.Core.Entities;

namespace TostiTime.Core.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    Task<IReadOnlyCollection<T>?> Get(ISpecification<T> specification);
    Task<T?> GetSingle(ISpecification<T> specification);
    Task<T> Insert(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task Commit();
}
