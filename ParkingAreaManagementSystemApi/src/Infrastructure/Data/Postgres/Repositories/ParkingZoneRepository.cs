using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Bases;
using Infrastructure.Data.Postgres.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres.Repositories;

public class ParkingZoneRepository(PostgresContext postgresContext)
    : Repository<ParkingZone, int>(postgresContext), IParkingZoneRepository
{
    public async Task<IList<ParkingZone>> GetAllParkingZonesWithIncludesAsync()
    {
        return await PostgresContext.ParkingZones
            .AsNoTracking()
            .AsSplitQuery()
            .OrderBy(parkingZone => parkingZone.Id)
            .Include(parkingZone => parkingZone.ParkingSpots.OrderBy(parkingSpot => parkingSpot.Id))
            .ToListAsync();
    }

    public async Task<ParkingZone?> GetMostAvailableParkingZoneUsingAllowedVehicleSizeAsync(
        AllowedVehicleSizeEnum allowedVehicleSize)
    {
        return await PostgresContext.ParkingZones
            .AsSplitQuery()
            .Include(parkingZone => parkingZone.ParkingSpots)
            .Select(parkingZone => new
            {
                ParkingZone = parkingZone,
                AvailableSpots = parkingZone.ParkingSpots.Count(parkingSpot =>
                    !parkingSpot.IsOccupied && parkingSpot.AllowedVehicleSize == allowedVehicleSize)
            })
            .OrderByDescending(x => x.AvailableSpots)
            .Select(x => x.ParkingZone)
            .FirstOrDefaultAsync();
    }
}