namespace ECommerceDomain.ValueObjects;

public sealed record FullName
{
    public Name Name { get; init; }
    public Name FirstName { get; init; }
    public Name LastName { get; init; }

    public FullName(Name name, Name firstName, Name lastName)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
    }
}
