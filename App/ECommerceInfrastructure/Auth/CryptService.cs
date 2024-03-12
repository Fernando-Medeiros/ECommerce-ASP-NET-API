using ECommerceApplication.Contract;

namespace ECommerceInfrastructure.Auth;

public sealed class CryptService : ICryptService
{
    public string Hash(string? password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string? password, string? passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
