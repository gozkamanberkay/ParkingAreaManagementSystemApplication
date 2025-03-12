namespace Infrastructure.Data.Postgres.Entities.Interface;

public interface ITrackedEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}