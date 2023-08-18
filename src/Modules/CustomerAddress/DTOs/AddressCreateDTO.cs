namespace ECommerce.Modules.CustomerAddress;

public struct AddressCreateDTO
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }

    public int Number { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
    public string? Type { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public DateTime? CreatedAt { get; set; }

    public static AddressCreateDTO ExtractProperties(
        AddressCreateRequest _,
        string customerId)
    {
        return new()
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = customerId,

            Number = _.Number,
            Street = _.Street,
            ZipCode = _.ZipCode,
            Type = _.Type,
            City = _.City,
            State = _.State,
            Country = _.Country,
            CreatedAt = DateTime.UtcNow,
        };
    }
}