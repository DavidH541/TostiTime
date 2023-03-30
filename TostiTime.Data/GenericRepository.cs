using Microsoft.EntityFrameworkCore;
using TostiTime.Core.Entities;
using TostiTime.Core.Interfaces;

namespace TostiTime.Data;

public class GenericRepository<T> : IRepository<T> where T : EntityBase
{
    protected readonly TostiTimeDb _dbContext;

    public GenericRepository(TostiTimeDb dbContext)
    {
        _dbContext = dbContext;
    }

    private IQueryable<T> BuildSpecificationQuery(ISpecification<T> specification)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        query = specification.Includes
            .Aggregate(query, (current, include) => current.Include(include));

        query = specification.IncludeStrings
            .Aggregate(query, (current, include) => current.Include(include));

        return query.Where(specification.Criteria);
    }

    public virtual async Task<IReadOnlyCollection<T>?> Get(ISpecification<T> specification)
    {
        return await BuildSpecificationQuery(specification).ToListAsync();
    }

    public virtual async Task<T?> GetSingle(ISpecification<T> specification)
    {
        return await BuildSpecificationQuery(specification).FirstOrDefaultAsync();
    }

    public virtual async Task<T> Insert(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
