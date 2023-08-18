namespace ECommerce.Modules.Sales;

public struct SalesResource
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateOnly CreatedAt { get; set; }

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
