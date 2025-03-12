using System.Linq.Expressions;
using Infrastructure.Data.Postgres.Entities.Bases;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Interfaces.Bases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres.Repositories.Bases;

public abstract class TrackedEntityRepository<TEntity, TId>(PostgresContext postgresContext)
    : ITrackedEntityRepository<TEntity, TId>
    where TEntity : TrackedBaseEntity<TId>
{
    public async Task AddAsync(TEntity entity)
    {
        await postgresContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await postgresContext.Set<TEntity>().AddRangeAsync(entities);
    }

    public async Task RemoveByIdAsync(TId id)
    {
        var entity = await GetByIdAsync(id, tracked: true);

        if (entity != null) entity.IsDeleted = true;
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        var entityIdsToRemove = entities.Select(x => x.Id);

        var entitiesToRemove = await FindAsync(x => entityIdsToRemove.Contains(x.Id), tracked: true);

        foreach (var entityToRemove in entitiesToRemove) entityToRemove.IsDeleted = true;
    }

    public async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false,
        bool tracked = false)
    {
        var query = postgresContext.Set<TEntity>().Where(predicate);

        if (!includeDeleted) query = query.Where(x => !x.IsDeleted);

        if (!tracked) return await query.AsNoTracking().ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<IList<TEntity>> GetAllAsync(bool includeDeleted = false, bool tracked = false)
    {
        var query = includeDeleted
            ? postgresContext.Set<TEntity>()
            : postgresContext.Set<TEntity>().Where(x => !x.IsDeleted);

        if (!tracked) return await query.AsNoTracking().ToListAsync();

        return await query.ToListAsync();
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false)
    {
        var query = postgresContext.Set<TEntity>().Where(predicate);

        if (!includeDeleted) query = query.Where(x => !x.IsDeleted);

        return query.CountAsync();
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        bool includeDeleted = false, bool tracked = false)
    {
        var query = postgresContext.Set<TEntity>().Where(predicate);

        if (!includeDeleted) query = query.Where(x => !x.IsDeleted);

        if (!tracked) return await query.AsNoTracking().FirstOrDefaultAsync();

        return await query.FirstOrDefaultAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id, bool includeDeleted = false, bool tracked = false)
    {
        var entity = await postgresContext.Set<TEntity>().FindAsync(id);

        if (entity != null)
        {
            if (!includeDeleted && entity.IsDeleted)
            {
                entity = null;
            }
            else
            {
                if (!tracked) postgresContext.Entry(entity).State = EntityState.Detached;
            }
        }

        return entity;
    }
}