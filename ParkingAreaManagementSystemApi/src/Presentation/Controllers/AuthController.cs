using Business.Models.Requests;
using Business.Models.Responses;
using Business.Services.Interfaces;
using Business.Utilities.Security.Auth.Jwt.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Bases;

namespace Presentation.Controllers;

public class AuthController(IAuthService authService) : BaseController
{
    [HttpPost]
    public async Task<ActionResult<DataResult<Token>>> Register(RegisterRequestDto request)
    {
        return await authService.RegisterAsync(request);
    }

    [HttpPost]
    public async Task<ActionResult<DataResult<Token>>> Login(LoginRequestDto request)
    {
        return await authService.LoginAsync(request);
    }

    [HttpGet]
    public async Task<ActionResult<DataResult<Token>>> RefreshToken(string refreshToken)
    {
        return await authService.RefreshTokenAsync(refreshToken);
    }
}