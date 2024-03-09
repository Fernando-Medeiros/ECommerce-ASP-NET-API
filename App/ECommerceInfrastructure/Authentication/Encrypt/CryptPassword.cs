using ECommerceApplication.Contract;

namespace ECommerceInfrastructure.Authentication.Encrypt;

public class CryptPassword : ICryptPassword
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
