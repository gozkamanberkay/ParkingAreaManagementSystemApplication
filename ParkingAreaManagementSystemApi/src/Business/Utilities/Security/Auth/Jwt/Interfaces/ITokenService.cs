using Business.Utilities.Security.Auth.Jwt.Models;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Utilities.Security.Auth.Jwt.Interfaces;

public interface ITokenService
{
    Token CreateJwtToken(User user, string refreshToken);
}