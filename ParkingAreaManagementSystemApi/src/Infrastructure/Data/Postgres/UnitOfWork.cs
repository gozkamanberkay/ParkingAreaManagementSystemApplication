using Infrastructure.Data.Postgres.Entities.Interface;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories;
using Infrastructure.Data.Postgres.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres;

public class UnitOfWork(PostgresContext postgresContext) : IUnitOfWork
{
    private ParkingRecordRepository? _parkingRecordRepository;
    private ParkingSpotRepository? _parkingSpotRepository;
    private ParkingZoneRepository? _parkingZoneRepository;
    private UserRepository? _userRepository;
    private UserTokenRepository? _userTokenRepository;

    public IParkingRecordRepository ParkingRecords =>
        _parkingRecordRepository ??= new ParkingRecordRepository(postgresContext);

    public IParkingSpotRepository ParkingSpots => _parkingSpotRepository ??= new ParkingSpotRepository(postgresContext);
    public IParkingZoneRepository ParkingZones => _parkingZoneRepository ??= new ParkingZoneRepository(postgresContext);
    public IUserRepository Users => _userRepository ??= new UserRepository(postgresContext);
    public IUserTokenRepository UserTokens => _userTokenRepository ??= new UserTokenRepository(postgresContext);

    public async Task<int> CommitAsync()
    {
        var updatedTrackedEntities = postgresContext.ChangeTracker
            .Entries<ITrackedEntity>()
            .Where(e => e.State == EntityState.Modified)
            .Select(e => e.Entity);

        foreach (var updatedEntity in updatedTrackedEntities) updatedEntity.UpdatedAt = DateTime.UtcNow;

        var result = await postgresContext.SaveChangesAsync();

        return result;
    }

    public void DisposeContext()
    {
        postgresContext.Dispose();
    }
}