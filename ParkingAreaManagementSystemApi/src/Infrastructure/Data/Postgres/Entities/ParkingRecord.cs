using Infrastructure.Data.Postgres.Entities.Bases;

namespace Infrastructure.Data.Postgres.Entities;

public class ParkingRecord : TrackedBaseEntity<int>
{
    public string PlateNumber { get; set; } = default!;
    public int ParkingSpotId { get; set; } = default!;
    public DateTime CheckedInAt { get; init; } = default!;
    public DateTime? CheckedOutAt { get; set; } = default!;
    public double HourlyFee { get; set; } = default!;
    public ParkingRecordStatusEnum Status { get; set; } = default!;
    public double? ParkDurationInHours => CheckedOutAt.HasValue ? (CheckedOutAt.Value - CheckedInAt).TotalHours : null;
    public double? TotalFee => ParkDurationInHours * HourlyFee;

    public virtual ParkingSpot ParkingSpot { get; set; } = null!;
}

public enum ParkingRecordStatusEnum
{
    CheckedIn = 0,
    CheckedOut = 10
}