using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Responses;

public record CheckInResponseDto
{
    public string ParkingZoneName { get; set; } = default!;
    public string ParkingSpotName { get; set; } = default!;
    public AllowedVehicleSizeEnum ParkingSpotAllowedVehicleSize { get; set; } = default!;
}