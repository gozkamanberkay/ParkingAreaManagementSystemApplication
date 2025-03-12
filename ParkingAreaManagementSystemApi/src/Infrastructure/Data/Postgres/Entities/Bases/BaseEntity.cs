namespace Infrastructure.Data.Postgres.Entities.Bases;

public abstract class BaseEntity<T>
{
    public T Id { get; set; } = default!;
}