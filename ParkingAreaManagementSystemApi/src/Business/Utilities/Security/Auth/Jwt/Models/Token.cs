namespace Business.Utilities.Security.Auth.Jwt.Models;

public class Token(string accessToken, DateTime expires, string refreshToken)
{
    public string AccessToken { get; set; } = accessToken;
    public DateTime Expires { get; set; } = expires;
    public string RefreshToken { get; set; } = refreshToken;
}

public static class TokenConstants
{
    public const int JwtTokenValidUntilMinutes = 30;
    public const int RefreshTokenValidUntilDays = 15;
}