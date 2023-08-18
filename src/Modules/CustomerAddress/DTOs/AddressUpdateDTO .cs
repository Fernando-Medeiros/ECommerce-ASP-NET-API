namespace ECommerce.Modules.CustomerAddress;

public struct AddressUpdateDTO
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }

    public int? Number { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
    public string? Type { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }

    public static AddressUpdateDTO ExtractProperties(
        AddressUpdateRequest _,
        string addressId, string customerId)
    {
        return new()
        {
            Id = addressId,
            CustomerId = customerId,

            Number = _.Number,
            Street = _.Street,
            ZipCode = _.ZipCode,
            Type = _.Type,
            City = _.City,
            State = _.State,
            Country = _.Country,
        };
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
    }
}