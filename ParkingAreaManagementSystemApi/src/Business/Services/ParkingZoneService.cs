using Business.Models.Responses;
using Business.Services.Interfaces;
using Infrastructure.Data.Postgres;

namespace Business.Services;

public class ParkingZoneService(IUnitOfWork unitOfWork) : IParkingZoneService
{
    public async Task<DataResult<IList<ParkingZoneResponseDto>>> GetAllParkingZones()
    {
        var parkingZones = await unitOfWork.ParkingZones.GetAllParkingZonesWithIncludesAsync();

        var mappedParkingZones = ParkingZoneResponseDtoExtensions.MapFrom(parkingZones);

        return new DataResult<IList<ParkingZoneResponseDto>>(ResultStatus.Ok, data: mappedParkingZones);
    }
}