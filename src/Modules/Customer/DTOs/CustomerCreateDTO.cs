namespace ECommerce.Modules.Customer;

using BCrypt.Net;

public readonly struct CustomerCreateDTO
{
    public readonly string? Id;
    public readonly string? Name;
    public readonly string? FirstName;
    public readonly string? LastName;
    public readonly string? Email;
    public readonly string? Password;
    public readonly DateTime CreatedAt;

    public CustomerCreateDTO(
        string? name,
        string? firstName,
        string? lastName,
        string? email,
        string? password)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = BCrypt.HashPassword(password);
        CreatedAt = DateTime.UtcNow;
    }

    public static CustomerCreateDTO ExtractProperties(
        CustomerCreateRequest req)
    {
        return new(
            name: req.Name,
            firstName: req.FirstName,
            lastName: req.LastName,
            email: req.Email,
            password: req.Password);
    }
}
