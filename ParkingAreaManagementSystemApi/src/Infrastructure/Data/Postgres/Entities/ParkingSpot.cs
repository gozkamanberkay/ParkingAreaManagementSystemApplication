using Infrastructure.Data.Postgres.Entities.Bases;

namespace Infrastructure.Data.Postgres.Entities;

public class ParkingSpot : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public int ParkingZoneId { get; set; } = default!;
    public bool IsOccupied { get; set; } = default!;
    public AllowedVehicleSizeEnum AllowedVehicleSize { get; set; } = AllowedVehicleSizeEnum.Small;
    public string AllowedVehicleSizeString => AllowedVehicleSize.ToString();

    public virtual ParkingZone ParkingZone { get; set; } = default!;
}

public enum AllowedVehicleSizeEnum
{
    Small = 5,
    Medium = 10,
    Big = 15
}