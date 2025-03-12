using System.Linq.Expressions;

namespace Infrastructure.Data.Postgres.Repositories.Interfaces.Bases;

public interface IRepository<TEntity, in TId> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    Task RemoveById(TId id);
    void RemoveRange(IEnumerable<TEntity> entities);
    Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false);
    Task<IList<TEntity>> GetAllAsync(bool tracked = false);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracked = false);
    ValueTask<TEntity?> GetByIdAsync(TId id, bool tracked = false);
}