using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Responses;

public record ParkingZoneResponseDto
{
    public string Name { get; set; } = default!;
    public int Capacity { get; set; }
    public double HourlyFee { get; set; }

    public IList<ParkingSpotResponseDto> ParkingSpots { get; set; } = default!;
}

public static class ParkingZoneResponseDtoExtensions
{
    public static IList<ParkingZoneResponseDto> MapFrom(IList<ParkingZone> parkingZones)
    {
        return parkingZones.Select(parkingZone => new ParkingZoneResponseDto
        {
            Name = parkingZone.Name,
            Capacity = parkingZone.Capacity,
            HourlyFee = parkingZone.HourlyFee,
            ParkingSpots = parkingZone.ParkingSpots.Select(parkingSpot => new ParkingSpotResponseDto
            {
                Name = parkingSpot.Name,
                IsOccupied = parkingSpot.IsOccupied,
                AllowedVehicleSize = parkingSpot.AllowedVehicleSizeString
            }).ToList()
        }).ToList();
    }
}