using Business.Models.Requests;
using Business.Models.Responses;

namespace Business.Services.Interfaces;

public interface ICheckService
{
    Task<DataResult<CheckInResponseDto>> CheckIn(CheckInRequestDto request);
    Task<DataResult<CheckOutResponseDto>> CheckOut(CheckOutRequestDto request);
}