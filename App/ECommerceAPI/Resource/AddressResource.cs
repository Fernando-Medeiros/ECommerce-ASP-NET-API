using ECommerceDomain.DTO;

namespace ECommerceAPI.Resource;

public readonly struct AddressResource(AddressDTO x)
{
    public string? Id { get; init; } = x.Id;
    public string? Code { get; init; } = x.Code;
    public string? City { get; init; } = x.City;
    public string? State { get; init; } = x.State;
    public string? Street { get; init; } = x.Street;
    public DateOnly? CreatedOn { get; init; } = DateOnly.FromDateTime(x.CreatedOn!.Value.DateTime);


    public static IEnumerable<AddressResource> ToArray(
        IEnumerable<AddressDTO> addresses)
    {
        List<AddressResource> collection = [];

        foreach (var address in addresses)
        {
            collection.Add(new(address));
        }

        return collection;
    }
}