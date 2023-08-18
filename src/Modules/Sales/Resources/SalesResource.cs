namespace ECommerce.Modules.Sales;

public readonly struct SalesResource
{
    public readonly string? Id { get; init; }
    public readonly string? CustomerId { get; init; }
    public readonly string? ProductId { get; init; }
    public readonly decimal Price { get; init; }
    public readonly int Quantity { get; init; }
    public readonly DateOnly CreatedAt { get; init; }

    public SalesResource(SalesDTO _)
    {
        Id = _.Id;
        CustomerId = _.CustomerId;
        ProductId = _.ProductId;
        Price = _.Price;
        Quantity = _.Quantity;
        CreatedAt = DateOnly.FromDateTime(_.CreatedAt!.Value);
    }

    public static IEnumerable<SalesResource> ToArray(
        IEnumerable<SalesDTO?> array)
    {
        var carts = new List<SalesResource>();

        foreach (var dto in array)
            if (dto != null) carts.Add(new SalesResource(dto));

        return carts;
    }
}
