namespace ECommerce.Modules.CustomerAddress;

public readonly struct AddressCreateDTO
{
    public readonly string? Id;
    public readonly string? CustomerId;
    public readonly int Number;
    public readonly string? Street;
    public readonly string? ZipCode;
    public readonly string? Type;
    public readonly string? City;
    public readonly string? State;
    public readonly string? Country;
    public readonly DateTime CreatedAt;

    public AddressCreateDTO(
        string? customerId,
        int number,
        string? street,
        string? zipCode,
        string? type,
        string? city,
        string? state,
        string? country)
    {
        Id = Guid.NewGuid().ToString();
        CustomerId = customerId;
        Number = number;
        Street = street;
        ZipCode = zipCode;
        Type = type;
        City = city;
        State = state;
        Country = country;
        CreatedAt = DateTime.UtcNow;
    }

    public static AddressCreateDTO ExtractProperties(
        AddressCreateRequest req, string customerId)
    {
        return new(
            customerId: customerId,
            number: req.Number,
            street: req.Street,
            zipCode: req.ZipCode,
            type: req.Type,
            city: req.City,
            state: req.State,
            country: req.Country);
    }
}