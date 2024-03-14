using ECommerceDomain.Abstraction;
using ECommerceDomain.ClusterObjects;
using ECommerceDomain.DTO;
using ECommerceDomain.Enums;
using ECommerceDomain.ValueObjects;

namespace ECommerceDomain.Entities;

public sealed class Customer() : Entity
{
    public Role? Role { get; private set; }
    public Email? Email { get; private set; }
    public FullName? Name { get; private set; }
    public Password? Password { get; private set; }
    public Date? VerifiedOn { get; private set; }

    public Customer(CustomerDTO x) : this()
    {
        Id = new(x.Id);
        Name = new(
            new(x.Name),
            new(x.FirstName),
            new(x.LastName));
        Role = new(x.Role);
        Email = new(x.Email);
        Password = new(x.Password);
        CreatedOn = new(x.CreatedOn);
        UpdatedOn = new(x.UpdatedOn, required: false);
        VerifiedOn = new(x.VerifiedOn, required: false);
    }

    public Customer Register(CustomerDTO x)
    {
        Id = new(Guid.NewGuid().ToString());
        Name = new(
            new(x.Name),
            new(x.FirstName),
            new(x.LastName));
        Email = new(x.Email);
        Password = new(x.Password);
        Role = new(nameof(ERole.customer));
        CreatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Customer UpdateName(CustomerDTO x)
    {
        Name = new(
            new(x.Name, required: false),
            new(x.FirstName, required: false),
            new(x.LastName, required: false));
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Customer UpdateEmail(CustomerDTO x)
    {
        Email = new(x.Email, required: false);
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Customer UpdatePassword(CustomerDTO x)
    {
        Password = new(x.Password, required: false);
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Customer UpdateRole(CustomerDTO x)
    {
        Role = new(x.Role, required: false);
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Customer AssignVerified()
    {
        VerifiedOn = new(DateTimeOffset.UtcNow);
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }
}

