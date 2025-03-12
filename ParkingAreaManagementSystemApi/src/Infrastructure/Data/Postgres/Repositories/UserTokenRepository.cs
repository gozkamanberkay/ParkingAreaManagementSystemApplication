using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Bases;
using Infrastructure.Data.Postgres.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres.Repositories;

public class UserTokenRepository(PostgresContext postgresContext)
    : Repository<UserToken, string>(postgresContext), IUserTokenRepository
{
    public async Task<UserToken?> GetUserTokenWithUserAsync(string token)
    {
        return await PostgresContext.UserTokens
            .AsNoTracking()
            .Include(u => u.User)
            .FirstOrDefaultAsync(u => u.Token == token);
    }
}