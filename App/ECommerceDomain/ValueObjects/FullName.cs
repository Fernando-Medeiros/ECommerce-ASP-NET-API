namespace ECommerceDomain.ValueObjects;

public sealed class FullName
{
    public Name Name { get; private set; } = new();
    public Name FirstName { get; private set; } = new();
    public Name LastName { get; private set; } = new();
}
