using ECommerceDomain.Abstractions;
using ECommerceDomain.DTOs;
using ECommerceDomain.ValueObjects;

namespace ECommerceDomain.Entities;

public sealed class CustomerEntity : Entity
{
    public Email Email { get; private set; } = new();
    public FullName Name { get; private set; } = new();
    public Password Password { get; private set; } = new();
    public Role Role { get; private set; } = new();

    public DateTimeOffset? VerifiedAt { get; private set; }

    public CustomerEntity LoadState(CustomerDTO x)
    {
        Id.Validate(x.Id).Set(x.Id);

        Email.Validate(x.Email).Set(x.Email);
        Name.Name.Validate(x.Name).Set(x.Name);
        Name.FirstName.Validate(x.FirstName).Set(x.FirstName);
        Name.LastName.Validate(x.LastName).Set(x.LastName);

        Password.Validate(x.Password).Set(x.Password);

        Role.Validate(x.Role).Set(x.Role);

        VerifiedAt = x?.VerifiedAt;
        UpdatedAt = x?.UpdatedAt;
        CreatedAt = x?.CreatedAt;
        return this;
    }

    public CustomerEntity Register(CustomerDTO x)
    {
        Id.Set(Guid.NewGuid().ToString());

        Email.Validate(x.Email).Set(x.Email);

        Name.Name.Validate(x.Name).Set(x.Name);
        Name.FirstName.Validate(x.FirstName).Set(x.FirstName);
        Name.LastName.Validate(x.LastName).Set(x.LastName);

        Password.Validate(x.Password).Set(x.Password);

        CreatedAt = DateTimeOffset.UtcNow;
        return this;
    }

    public CustomerEntity UpdateName(CustomerDTO x)
    {
        Name.Name.Optional().Validate(x.Name).Set(x.Name);
        Name.FirstName.Optional().Validate(x.FirstName).Set(x.FirstName);
        Name.LastName.Optional().Validate(x.LastName).Set(x.LastName);

        UpdatedAt = DateTimeOffset.UtcNow;
        return this;
    }

    public CustomerEntity UpdateEmail(CustomerDTO x)
    {
        Email.Optional().Validate(x.Email).Set(x.Email);

        UpdatedAt = DateTimeOffset.UtcNow;
        return this;
    }

    public CustomerEntity UpdatePassword(CustomerDTO x)
    {
        Password.Optional().Validate(x.Password).Set(x.Password);

        UpdatedAt = DateTimeOffset.UtcNow;
        return this;
    }

    public CustomerEntity UpdateRole(CustomerDTO x)
    {
        Role.Optional().Validate(x.Role).Set(x.Role);

        UpdatedAt = DateTimeOffset.UtcNow;
        return this;
    }

    public CustomerEntity AssignVerified()
    {
        VerifiedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
        return this;
    }
}

