using Business.Models.Requests;
using Business.Models.Responses;
using Business.Services.Interfaces;
using Core.Constants;
using Core.Extensions;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Services;

public class CheckService(IUnitOfWork unitOfWork) : ICheckService
{
    private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);

    public async Task<DataResult<CheckInResponseDto>> CheckIn(CheckInRequestDto request)
    {
        await _semaphoreSlim.WaitAsync();

        try
        {
            var parkingRecord = await unitOfWork.ParkingRecords.FirstOrDefaultAsync(parkingRecord =>
                parkingRecord.PlateNumber == request.PlateNumber &&
                parkingRecord.Status == ParkingRecordStatusEnum.CheckedIn);

            if (parkingRecord != null)
                return new DataResult<CheckInResponseDto>(ResultStatus.Error, Messages.ParkingRecordNotFound);

            var parkingZone = await unitOfWork.ParkingZones
                .GetMostAvailableParkingZoneUsingAllowedVehicleSizeAsync(request.AllowedVehicleSize);

            var parkingSpot = parkingZone?.ParkingSpots.FirstOrDefault(parkingSpot =>
                !parkingSpot.IsOccupied && parkingSpot.AllowedVehicleSize == request.AllowedVehicleSize);

            if (parkingZone == null || parkingSpot == null)
            {
                var message = parkingZone == null ? Messages.ParkingZoneNotFound : Messages.ParkingSpotNotFound;
                
                return new DataResult<CheckInResponseDto>(status: ResultStatus.Error, message: message);
            }

            parkingSpot.IsOccupied = true;

            parkingRecord = new ParkingRecord
            {
                PlateNumber = request.PlateNumber,
                ParkingSpotId = parkingSpot.Id,
                CheckedInAt = DateTime.UtcNow,
                HourlyFee = parkingZone.HourlyFee,
                Status = ParkingRecordStatusEnum.CheckedIn
            };

            await unitOfWork.ParkingRecords.AddAsync(parkingRecord);

            await unitOfWork.CommitAsync();

            var checkInResponseDto = new CheckInResponseDto
            {
                ParkingZoneName = parkingZone.Name,
                ParkingSpotName = parkingSpot.Name,
                ParkingSpotAllowedVehicleSize = parkingSpot.AllowedVehicleSize
            };

            return new DataResult<CheckInResponseDto>(status: ResultStatus.Ok, message: Messages.Success, data: checkInResponseDto);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    public async Task<DataResult<CheckOutResponseDto>> CheckOut(CheckOutRequestDto request)
    {
        await _semaphoreSlim.WaitAsync();

        try
        {
            var parkingRecord = await unitOfWork.ParkingRecords.GetByPlateNumberToCheckOutAsync(request.PlateNumber);

            var parkingSpot = parkingRecord?.ParkingSpot;

            if (parkingRecord == null || parkingSpot == null)
                return new DataResult<CheckOutResponseDto>(ResultStatus.Error, Messages.NotFound);

            parkingRecord.CheckedOutAt = DateTime.UtcNow;
            parkingRecord.Status = ParkingRecordStatusEnum.CheckedOut;

            parkingSpot.IsOccupied = false;

            await unitOfWork.CommitAsync();

            var checkOutResponseDto = new CheckOutResponseDto
            {
                CheckedInAt = parkingRecord.CheckedInAt.ToTimeZone(),
                CheckedOutAt = parkingRecord.CheckedOutAt.Value.ToTimeZone(),
                TotalFee = parkingRecord.TotalFee.GetValueOrDefault(),
                ParkDurationInHours = parkingRecord.ParkDurationInHours.GetValueOrDefault(),
                HourlyFee = parkingRecord.HourlyFee
            };

            return new DataResult<CheckOutResponseDto>(status: ResultStatus.Ok, message: Messages.Success, data: checkOutResponseDto);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
}