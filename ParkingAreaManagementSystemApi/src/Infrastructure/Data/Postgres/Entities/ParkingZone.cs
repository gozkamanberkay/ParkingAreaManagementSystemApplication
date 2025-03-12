using Infrastructure.Data.Postgres.Entities.Bases;

namespace Infrastructure.Data.Postgres.Entities;

public class ParkingZone : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public int Capacity { get; set; } = default!;
    public double HourlyFee { get; set; } = default!;

    public virtual IList<ParkingSpot> ParkingSpots { get; set; } = default!;
}