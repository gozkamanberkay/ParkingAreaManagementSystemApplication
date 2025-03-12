using Business.Models.Requests;
using Business.Models.Responses;
using Business.Utilities.Security.Auth.Jwt.Models;

namespace Business.Services.Interfaces;

public interface IAuthService
{
    Task<DataResult<Token>> LoginAsync(LoginRequestDto loginRequestDto);
    Task<DataResult<Token>> RegisterAsync(RegisterRequestDto registerRequestDto);
    Task<DataResult<Token>> RefreshTokenAsync(string refreshToken);
}