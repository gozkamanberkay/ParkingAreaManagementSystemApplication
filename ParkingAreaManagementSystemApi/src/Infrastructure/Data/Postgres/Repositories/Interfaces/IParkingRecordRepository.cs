using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Interfaces.Bases;

namespace Infrastructure.Data.Postgres.Repositories.Interfaces;

public interface IParkingRecordRepository : IRepository<ParkingRecord, int>
{
    Task<ParkingRecord?> GetByPlateNumberToCheckOutAsync(string plateNumber);
}