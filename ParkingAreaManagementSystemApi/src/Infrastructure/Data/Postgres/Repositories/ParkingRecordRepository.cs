using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Bases;
using Infrastructure.Data.Postgres.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres.Repositories;

public class ParkingRecordRepository(PostgresContext postgresContext)
    : Repository<ParkingRecord, int>(postgresContext), IParkingRecordRepository
{
    public async Task<ParkingRecord?> GetByPlateNumberToCheckOutAsync(string plateNumber)
    {
        return await PostgresContext.ParkingRecords
            .Include(parkingRecord => parkingRecord.ParkingSpot)
            .FirstOrDefaultAsync(parkingRecord => parkingRecord.PlateNumber == plateNumber &&
                                                  parkingRecord.Status == ParkingRecordStatusEnum.CheckedIn);
    }
}