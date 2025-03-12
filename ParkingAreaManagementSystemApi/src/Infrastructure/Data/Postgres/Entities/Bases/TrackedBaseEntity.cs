using Infrastructure.Data.Postgres.Entities.Interface;

namespace Infrastructure.Data.Postgres.Entities.Bases;

public class TrackedBaseEntity<T> : BaseEntity<T>, ITrackedEntity
{
    protected TrackedBaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = null!;
    public bool IsDeleted { get; set; }
}