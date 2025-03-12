using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Bases;
using Infrastructure.Data.Postgres.Repositories.Interfaces;

namespace Infrastructure.Data.Postgres.Repositories;

public class ParkingSpotRepository(PostgresContext postgresContext)
    : Repository<ParkingSpot, int>(postgresContext), IParkingSpotRepository;