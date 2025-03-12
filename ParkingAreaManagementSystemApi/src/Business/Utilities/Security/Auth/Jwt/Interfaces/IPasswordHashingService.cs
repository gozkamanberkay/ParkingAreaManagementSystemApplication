namespace Business.Utilities.Security.Auth.Jwt.Interfaces;

public interface IPasswordHashingService
{
    void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
}