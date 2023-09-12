using ECommerce.Modules.CustomerPassword;

namespace ECommerce.Modules.Customer;

public class CustomerDomain
{
    public string? Id { get; private set; }
    public string? Name { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Email { get; private set; }

    public string? Password { get; private set; }
    public string? Role { get; private set; }

    public DateTime? VerifiedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? CreatedAt { get; private set; }

    public CustomerDomain LoadState(CustomerDTO x)
    {
        Id = x.Id;
        Name = x.Name;
        FirstName = x.FirstName;
        LastName = x.LastName;
        Email = x.Email;

        Password = x.Password;
        Role = x?.Role;

        VerifiedAt = x?.VerifiedAt;
        UpdatedAt = x?.UpdatedAt;
        CreatedAt = x?.CreatedAt;

        return this;
    }

    public CustomerDomain Register(CustomerCreateDTO x)
    {
        Id = Guid.NewGuid().ToString();

        Name = x.Name;
        FirstName = x.FirstName;
        LastName = x.LastName;
        Email = x.Email;
        Password = x.Password;

        CreatedAt = DateTime.UtcNow;

        return this;
    }

    public CustomerDomain Update(CustomerUpdateDTO x)
    {
        Name = x.Name ?? Name;
        FirstName = x.FirstName ?? FirstName;
        LastName = x.LastName ?? LastName;
        Email = x.Email ?? Email;

        UpdatedAt = DateTime.UtcNow;

        return this;
    }

    public CustomerDomain UpdatePassword(PasswordUpdateDTO x)
    {
        Password = x.Password;

        UpdatedAt = DateTime.UtcNow;

        return this;
    }

    public CustomerDomain AssignVerified()
    {
        VerifiedAt = DateTime.UtcNow;

        UpdatedAt = DateTime.UtcNow;

        return this;
    }
}

