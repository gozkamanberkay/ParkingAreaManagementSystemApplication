using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Utilities.Security.Auth.Jwt.Interfaces;
using Business.Utilities.Security.Auth.Jwt.Models;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Business.Utilities.Security.Auth.Jwt;

public class TokenService : ITokenService
{
    public Token CreateJwtToken(User user, string refreshToken)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_super_secret_key_is_super_secret_and_long"));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var notBefore = DateTime.UtcNow;
        var expires = notBefore.AddMinutes(TokenConstants.JwtTokenValidUntilMinutes);

        var securityToken = new JwtSecurityToken(
            issuer: "parkingareamanagementsystem.com",
            audience: "parkingareamanagementsystem.com",
            claims: [new Claim(JwtRegisteredClaimNames.Sub, user.Email)],
            notBefore: notBefore,
            expires: expires,
            signingCredentials: signingCredentials
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return new Token(accessToken: accessToken, expires: expires, refreshToken: refreshToken);
    }
}