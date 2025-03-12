using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Bases;
using Infrastructure.Data.Postgres.Repositories.Interfaces;

namespace Infrastructure.Data.Postgres.Repositories;

public class UserRepository(PostgresContext postgresContext) : Repository<User, long>(postgresContext), IUserRepository;