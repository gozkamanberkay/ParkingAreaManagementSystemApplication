using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Interfaces.Bases;

namespace Infrastructure.Data.Postgres.Repositories.Interfaces;

public interface IParkingSpotRepository : IRepository<ParkingSpot, int>;