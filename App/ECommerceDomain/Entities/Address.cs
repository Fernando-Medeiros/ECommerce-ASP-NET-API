using ECommerceDomain.Abstraction;
using ECommerceDomain.DTO;
using ECommerceDomain.ValueObjects;

namespace ECommerceDomain.Entities;

public sealed class Address() : Entity
{
    public Code? Code { get; private set; }
    public City? City { get; private set; }
    public State? State { get; private set; }
    public Street? Street { get; private set; }
    public UUID? CustomerID { get; private set; }

    public Address(AddressDTO x) : this()
    {
        Id = new(x.Id);
        City = new(x.City);
        State = new(x.State);
        Street = new(x.Street);
        Code = new(x.Code);
        CustomerID = new(x.CustomerId);
        CreatedOn = new(x.CreatedOn);
        UpdatedOn = new(x.UpdatedOn, required: false);
    }

    public Address Register(AddressDTO x)
    {
        Id = new(Guid.NewGuid().ToString());
        City = new(x.City);
        State = new(x.State);
        Street = new(x.Street);
        Code = new(x.Code);
        CustomerID = new(x.CustomerId);
        CreatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Address UpdateCode(AddressDTO x)
    {
        Code = new(x.Code, required: false);
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Address UpdateCity(AddressDTO x)
    {
        City = new(x.City, required: false);
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Address UpdateState(AddressDTO x)
    {
        State = new(x.State, required: false);
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }

    public Address UpdateStreet(AddressDTO x)
    {
        Street = new(x.Street, required: false);
        UpdatedOn = new(DateTimeOffset.UtcNow);
        return this;
    }
}