namespace ECommerceApplication.Contract;

public interface ICryptService
{
    public string Hash(string? password);

    public bool Verify(string? password, string? passwordHash);
}
