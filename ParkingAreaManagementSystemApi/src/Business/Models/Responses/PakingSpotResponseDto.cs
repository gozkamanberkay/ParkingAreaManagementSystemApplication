namespace Business.Models.Responses;

public record ParkingSpotResponseDto
{
    public string Name { get; set; } = default!;
    public bool IsOccupied { get; set; } = default!;
    public string AllowedVehicleSize { get; set; } = default!;
}