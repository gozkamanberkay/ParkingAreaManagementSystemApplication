using Business.Models.Responses;

namespace Business.Services.Interfaces;

public interface IParkingZoneService
{
    Task<DataResult<IList<ParkingZoneResponseDto>>> GetAllParkingZones();
}