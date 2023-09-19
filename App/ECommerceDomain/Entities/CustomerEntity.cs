using ECommerceDomain.Abstractions;
using ECommerceDomain.ClusterObjects;
using ECommerceDomain.DTOs;
using ECommerceDomain.Enums;
using ECommerceDomain.ValueObjects;

namespace ECommerceDomain.Entities;

public sealed class CustomerEntity : Entity
{
    public Email? Email { get; private set; }
    public FullName? Name { get; private set; }
    public Password? Password { get; private set; }
    public Role? Role { get; private set; }
    public Date? VerifiedOn { get; private set; }

    public CustomerEntity() { }

    public CustomerEntity(CustomerDTO x)
    {
        Id = new UUID(x.Id);

        Name = new FullName(
            new Name(x.Name),
            new Name(x.FirstName),
            new Name(x.LastName));

        Email = new Email(x.Email);

        Password = new Password(x.Password);

        Role = new Role(x.Role);

        VerifiedOn = new Date(x.VerifiedOn, required: false);
        UpdatedOn = new Date(x.UpdatedOn, required: false);
        CreatedOn = new Date(x.CreatedOn);
    }

    public CustomerEntity Register(CustomerDTO x)
    {
        Id = new UUID(Guid.NewGuid().ToString());

        Name = new FullName(
            new Name(x.Name),
            new Name(x.FirstName),
            new Name(x.LastName));

        Email = new Email(x.Email);

        Password = new Password(x.Password);

        Role = new Role(nameof(ERoles.customer));

        CreatedOn = new Date(DateTimeOffset.UtcNow);
        return this;
    }

    public CustomerEntity UpdateName(CustomerDTO x)
    {
        Name = new FullName(
            new Name(x.Name, required: false),
            new Name(x.FirstName, required: false),
            new Name(x.LastName, required: false));

        UpdatedOn = new Date(DateTimeOffset.UtcNow);
        return this;
    }

    public CustomerEntity UpdateEmail(CustomerDTO x)
    {
        Email = new Email(x.Email, required: false);

        UpdatedOn = new Date(DateTimeOffset.UtcNow);
        return this;
    }

    public CustomerEntity UpdatePassword(CustomerDTO x)
    {
        Password = new Password(x.Password, required: false);

        UpdatedOn = new Date(DateTimeOffset.UtcNow);
        return this;
    }

    public CustomerEntity UpdateRole(CustomerDTO x)
    {
        Role = new Role(x.Role, required: false);

        UpdatedOn = new Date(DateTimeOffset.UtcNow);
        return this;
    }

    public CustomerEntity AssignVerified()
    {
        VerifiedOn = new Date(DateTimeOffset.UtcNow);
        UpdatedOn = new Date(DateTimeOffset.UtcNow);
        return this;
    }
}

