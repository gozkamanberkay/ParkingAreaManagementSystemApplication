using Infrastructure.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

public class ParkingRecordConfiguration : IEntityTypeConfiguration<ParkingRecord>
{
    public void Configure(EntityTypeBuilder<ParkingRecord> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PlateNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.ParkingSpotId)
            .IsRequired();

        builder.Property(p => p.CheckedInAt)
            .IsRequired();

        builder.Property(p => p.CheckedOutAt);

        builder.Property(p => p.HourlyFee)
            .IsRequired();

        builder.Property(p => p.Status)
            .IsRequired();

        builder.Ignore(p => p.ParkDurationInHours);

        builder.Ignore(p => p.TotalFee);

        builder.HasOne(pr => pr.ParkingSpot)
            .WithMany()
            .HasForeignKey(pr => pr.ParkingSpotId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}