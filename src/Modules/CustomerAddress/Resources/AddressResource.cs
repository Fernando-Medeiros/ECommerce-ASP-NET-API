namespace ECommerce.Modules.CustomerAddress;

public readonly struct AddressResource
{
    public readonly string? Id { get; init; }
    public readonly int Number { get; init; }
    public readonly string? Street { get; init; }
    public readonly string? ZipCode { get; init; }
    public readonly string? Type { get; init; }
    public readonly string? City { get; init; }
    public readonly string? State { get; init; }
    public readonly string? Country { get; init; }
    public readonly DateOnly CreatedAt { get; init; }

    public AddressResource(AddressDTO _)
    {
        Id = _.Id;
        Number = _.Number;
        Street = _.Street;
        ZipCode = _.ZipCode;
        Type = _.Type;
        City = _.City;
        State = _.State;
        Country = _.Country;
        CreatedAt = DateOnly.FromDateTime(_.CreatedAt!.Value);
    }

    public static IEnumerable<AddressResource> ToArray(
        IEnumerable<AddressDTO?> array)
    {
        var addresses = new List<AddressResource>();

        foreach (var dto in array)
            if (dto != null) addresses.Add(new AddressResource(dto));

        return addresses;
    }
}