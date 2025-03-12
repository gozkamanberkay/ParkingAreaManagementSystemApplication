using Business.Models.Requests;
using Business.Models.Responses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Bases;

namespace Presentation.Controllers;

[Authorize]
public class DashboardController(ICheckService iCheckService, IParkingZoneService parkingZoneService) : BaseController
{
    [HttpPost]
    public async Task<ActionResult<DataResult<CheckInResponseDto>>> CheckIn(CheckInRequestDto request)
    {
        return await iCheckService.CheckIn(request);
    }

    [HttpPost]
    public async Task<ActionResult<DataResult<CheckOutResponseDto>>> CheckOut(CheckOutRequestDto request)
    {
        return await iCheckService.CheckOut(request);
    }

    [HttpGet]
    public async Task<ActionResult<DataResult<IList<ParkingZoneResponseDto>>>> GetAllParkingZones()
    {
        return await parkingZoneService.GetAllParkingZones();
    }
}