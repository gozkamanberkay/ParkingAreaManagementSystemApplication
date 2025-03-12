using Infrastructure.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

public class ParkingSpotConfiguration : IEntityTypeConfiguration<ParkingSpot>
{
    public void Configure(EntityTypeBuilder<ParkingSpot> builder)
    {
        builder.HasKey(ps => ps.Id);

        builder.Property(ps => ps.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ps => ps.IsOccupied)
            .IsRequired();

        builder.Property(p => p.AllowedVehicleSize)
            .IsRequired();

        builder.HasOne(ps => ps.ParkingZone)
            .WithMany(pz => pz.ParkingSpots)
            .HasForeignKey(ps => ps.ParkingZoneId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new ParkingSpot
            {
                Id = 1, Name = "A-1", ParkingZoneId = 1, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 2, Name = "A-2", ParkingZoneId = 1, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 3, Name = "A-3", ParkingZoneId = 1, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 4, Name = "A-4", ParkingZoneId = 1, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Medium
            },
            new ParkingSpot
            {
                Id = 5, Name = "A-5", ParkingZoneId = 1, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Medium
            },
            new ParkingSpot
            {
                Id = 6, Name = "A-6", ParkingZoneId = 1, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Big
            },
            new ParkingSpot
            {
                Id = 7, Name = "B-1", ParkingZoneId = 2, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 8, Name = "B-2", ParkingZoneId = 2, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 9, Name = "B-3", ParkingZoneId = 2, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Medium
            },
            new ParkingSpot
            {
                Id = 10, Name = "B-4", ParkingZoneId = 2, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Medium
            },
            new ParkingSpot
            {
                Id = 11, Name = "B-5", ParkingZoneId = 2, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Big
            },
            new ParkingSpot
            {
                Id = 12, Name = "B-6", ParkingZoneId = 2, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Big
            },
            new ParkingSpot
            {
                Id = 13, Name = "C-1", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 14, Name = "C-2", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 15, Name = "C-3", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 16, Name = "C-4", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Small
            },
            new ParkingSpot
            {
                Id = 17, Name = "C-5", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Medium
            },
            new ParkingSpot
            {
                Id = 18, Name = "C-6", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Medium
            },
            new ParkingSpot
            {
                Id = 19, Name = "C-7", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Medium
            },
            new ParkingSpot
            {
                Id = 20, Name = "C-8", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Big
            },
            new ParkingSpot
            {
                Id = 21, Name = "C-9", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Big
            },
            new ParkingSpot
            {
                Id = 22, Name = "C-10", ParkingZoneId = 3, IsOccupied = false,
                AllowedVehicleSize = AllowedVehicleSizeEnum.Big
            }
        );
    }
}