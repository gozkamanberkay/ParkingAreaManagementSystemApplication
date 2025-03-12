using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Interfaces.Bases;

namespace Infrastructure.Data.Postgres.Repositories.Interfaces;

public interface IParkingZoneRepository : IRepository<ParkingZone, int>
{
    Task<IList<ParkingZone>> GetAllParkingZonesWithIncludesAsync();

    Task<ParkingZone?> GetMostAvailableParkingZoneUsingAllowedVehicleSizeAsync(
        AllowedVehicleSizeEnum allowedVehicleSize);
}