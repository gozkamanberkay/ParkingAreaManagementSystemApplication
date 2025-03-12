using Infrastructure.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

public class ParkingZoneConfiguration : IEntityTypeConfiguration<ParkingZone>
{
    public void Configure(EntityTypeBuilder<ParkingZone> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Capacity)
            .IsRequired();

        builder
            .HasMany(pz => pz.ParkingSpots)
            .WithOne(ps => ps.ParkingZone)
            .HasForeignKey(ps => ps.ParkingZoneId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new ParkingZone { Id = 1, Name = "Parking Zone A", Capacity = 6, HourlyFee = 60.0 },
            new ParkingZone { Id = 2, Name = "Parking Zone B", Capacity = 6, HourlyFee = 100.0 },
            new ParkingZone { Id = 3, Name = "Parking Zone C", Capacity = 10, HourlyFee = 75.0 }
        );
    }
}