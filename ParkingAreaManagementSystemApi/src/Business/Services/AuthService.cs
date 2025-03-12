using Business.Models.Requests;
using Business.Models.Responses;
using Business.Services.Interfaces;
using Business.Utilities.Security.Auth.Jwt.Interfaces;
using Business.Utilities.Security.Auth.Jwt.Models;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Services;

public class AuthService(
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IPasswordHashingService passwordHashingService) : IAuthService
{
    public async Task<DataResult<Token>> RegisterAsync(RegisterRequestDto request)
    {
        if (await unitOfWork.Users.CountAsync(user => user.Email == request.Email) > 0)
            return new DataResult<Token>(ResultStatus.Error);

        passwordHashingService.CreatePasswordHash(password: request.Password, passwordHash: out var passwordHash, passwordSalt: out var passwordSalt);

        var user = new User
        {
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await unitOfWork.Users.AddAsync(user);

        await unitOfWork.CommitAsync();

        var refreshToken = new UserToken(tokenType: TokenType.RefreshToken, validUntil: DateTime.UtcNow.AddDays(TokenConstants.RefreshTokenValidUntilDays), userId: user.Id);

        await unitOfWork.UserTokens.AddAsync(refreshToken);

        var jwtToken = tokenService.CreateJwtToken(user: user, refreshToken: refreshToken.Token);

        await unitOfWork.CommitAsync();

        return new DataResult<Token>(ResultStatus.Ok, data: jwtToken);
    }

    public async Task<DataResult<Token>> LoginAsync(LoginRequestDto request)
    {
        var user = await unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null || !passwordHashingService.VerifyPasswordHash(password: request.Password, passwordHash: user.PasswordHash, passwordSalt: user.PasswordSalt))
            return new DataResult<Token>(ResultStatus.Error);

        var refreshToken = new UserToken(tokenType: TokenType.RefreshToken, validUntil: DateTime.UtcNow.AddDays(TokenConstants.RefreshTokenValidUntilDays), userId: user.Id);

        var jwtToken = tokenService.CreateJwtToken(user: user, refreshToken: refreshToken.Token);

        var userTokens = await unitOfWork.UserTokens.FindAsync(userToken => userToken.UserId == user.Id);

        unitOfWork.UserTokens.RemoveRange(userTokens);

        await unitOfWork.UserTokens.AddAsync(refreshToken);

        await unitOfWork.CommitAsync();

        return new DataResult<Token>(data: jwtToken, status: ResultStatus.Ok);
    }

    public async Task<DataResult<Token>> RefreshTokenAsync(string refreshToken)
    {
        var userToken = await unitOfWork.UserTokens.GetUserTokenWithUserAsync(refreshToken);

        if (userToken == null || userToken.User.IsDeleted) return new DataResult<Token>(ResultStatus.Error);

        var newRefreshToken = new UserToken(tokenType: TokenType.RefreshToken, validUntil: DateTime.UtcNow.AddDays(TokenConstants.RefreshTokenValidUntilDays), userId: userToken.UserId);

        await unitOfWork.UserTokens.AddAsync(newRefreshToken);

        unitOfWork.UserTokens.Remove(userToken);

        await unitOfWork.CommitAsync();

        var jwtToken = tokenService.CreateJwtToken(user: userToken.User, refreshToken: newRefreshToken.Token);

        return new DataResult<Token>(ResultStatus.Ok, data: jwtToken);
    }
}