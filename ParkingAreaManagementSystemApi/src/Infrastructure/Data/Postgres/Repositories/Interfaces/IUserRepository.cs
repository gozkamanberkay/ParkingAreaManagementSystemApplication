using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Interfaces.Bases;

namespace Infrastructure.Data.Postgres.Repositories.Interfaces;

public interface IUserRepository : IRepository<User, long>;