using Infrastructure.Data.Postgres.Repositories.Interfaces;

namespace Infrastructure.Data.Postgres;

public interface IUnitOfWork
{
    IParkingRecordRepository ParkingRecords { get; }
    IParkingZoneRepository ParkingZones { get; }
    IParkingSpotRepository ParkingSpots { get; }
    IUserRepository Users { get; }
    IUserTokenRepository UserTokens { get; }

    Task<int> CommitAsync();
    void DisposeContext();
}