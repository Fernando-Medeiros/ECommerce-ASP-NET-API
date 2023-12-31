namespace ECommerceApplication.Contracts;

public interface ICryptPassword
{
    public string Hash(string? password);

    public bool Verify(string? password, string? passwordHash);
}
