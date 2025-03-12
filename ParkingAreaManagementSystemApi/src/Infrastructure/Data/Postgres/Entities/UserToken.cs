namespace Infrastructure.Data.Postgres.Entities;

public class UserToken
{
    public UserToken(TokenType tokenType, DateTime validUntil, int userId)
    {
        Token = Guid.NewGuid().ToString();
        TokenType = tokenType;
        ValidUntil = validUntil;
        UserId = userId;
    }

    public string Token { get; set; } = default!;
    public TokenType TokenType { get; set; }
    public DateTime ValidUntil { get; set; }
    public int UserId { get; set; }

    public virtual User User { get; set; } = default!;
}

public enum TokenType
{
    RefreshToken,
    ResetPasswordToken
}