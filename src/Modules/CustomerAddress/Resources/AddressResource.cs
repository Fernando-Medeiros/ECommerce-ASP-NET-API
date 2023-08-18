namespace ECommerce.Modules.CustomerAddress;

public struct AddressResource
{
    public string? Id { get; set; }
    public int Number { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
    public string? Type { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public DateOnly CreatedAt { get; set; }

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