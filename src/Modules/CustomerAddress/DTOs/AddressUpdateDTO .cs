namespace ECommerce.Modules.CustomerAddress;

public readonly struct AddressUpdateDTO
{
    public readonly string? Id;
    public readonly string? CustomerId;
    public readonly int? Number;
    public readonly string? Street;
    public readonly string? ZipCode;
    public readonly string? Type;
    public readonly string? City;
    public readonly string? State;
    public readonly string? Country;
    public readonly DateTime UpdatedAt;

    public AddressUpdateDTO(
        string? id,
        string? customerId,
        int? number,
        string? street,
        string? zipCode,
        string? type,
        string? city,
        string? state,
        string? country)
    {
        Id = id;
        CustomerId = customerId;
        Number = number;
        Street = street;
        ZipCode = zipCode;
        Type = type;
        City = city;
        State = state;
        Country = country;
        UpdatedAt = DateTime.UtcNow;
    }

    public static AddressUpdateDTO ExtractProperties(
        AddressUpdateRequest req, string addressId, string customerId)
    {
        return new(
            id: addressId,
            customerId: customerId,
            number: req.Number,
            street: req.Street,
            zipCode: req.ZipCode,
            type: req.Type,
            city: req.City,
            state: req.State,
            country: req.Country);
    }

    public readonly void UpdateProperties(ref AddressDTO address)
    {
        if (Number != null) address.Number = (int)Number;

        if (Street != null) address.Street = Street;

        if (ZipCode != null) address.ZipCode = ZipCode;

        if (Type != null) address.Type = Type;

        if (City != null) address.City = City;

        if (State != null) address.State = State;

        if (Country != null) address.Country = Country;

        address.UpdatedAt = UpdatedAt;
    }
}