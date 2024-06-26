using ECommerceCommon.Exceptions;
using ECommerceDomain.Abstraction;
using ECommerceDomain.ValueObjects;

namespace ECommerceDomain.ClusterObjects;

public sealed record FullName : Cluster
{
    public Name Name { get; init; }
    public Name FirstName { get; init; }
    public Name LastName { get; init; }

    public FullName(Name name, Name firstName, Name lastName)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Validate();
    }

    protected override void Validate()
    {
        if (Name.Equals(Name, FirstName) ||
            Name.Equals(Name, LastName) ||
            Name.Equals(FirstName, LastName))
        {
            throw new FullNameFormatException().Target(nameof(FullName));
        }
    }
}
