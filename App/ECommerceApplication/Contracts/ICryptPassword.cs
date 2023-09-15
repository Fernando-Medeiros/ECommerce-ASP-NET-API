namespace ECommerceApplication.Contracts;

public interface ICryptPassword
{
    public string Hash(string? password, string? passwordHash);

    public bool Verify(string? password, string? passwordHash);
}
