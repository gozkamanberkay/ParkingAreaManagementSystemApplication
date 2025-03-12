using Infrastructure.Data.Postgres.Entities.Bases;

namespace Infrastructure.Data.Postgres.Entities;

public class User : TrackedBaseEntity<int>
{
    public string Email { get; set; } = default!;
    public byte[] PasswordSalt { get; set; } = default!;
    public byte[] PasswordHash { get; set; } = default!;
}