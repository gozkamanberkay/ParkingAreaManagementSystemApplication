using System.Linq.Expressions;
using Infrastructure.Data.Postgres.Entities.Bases;

namespace Infrastructure.Data.Postgres.Repositories.Interfaces.Bases;

public interface ITrackedEntityRepository<TEntity, in TId> where TEntity : TrackedBaseEntity<TId>
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task RemoveByIdAsync(TId id);
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);

    Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false,
        bool tracked = false);

    Task<IList<TEntity>> GetAllAsync(bool includeDeleted = false, bool tracked = false);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false);

    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false,
        bool tracked = false);

    Task<TEntity?> GetByIdAsync(TId id, bool includeDeleted = false, bool tracked = false);
}