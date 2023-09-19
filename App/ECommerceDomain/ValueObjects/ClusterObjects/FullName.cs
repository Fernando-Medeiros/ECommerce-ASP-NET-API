using ECommerceDomain.Abstractions;
using ECommerceDomain.Exceptions;
using ECommerceDomain.ValueObjects;

namespace ECommerceDomain.ClusterObjects;

public sealed record FullName : ClusterObject
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

    public override void Validate()
    {
        if (Name.Equals(Name, FirstName) ||
            Name.Equals(Name, LastName) ||
            Name.Equals(FirstName, LastName))
        {
            throw new FullNameFormatException().SetTarget(nameof(FullName));
        }
    }
}
