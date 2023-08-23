namespace ECommerce.Modules.CustomerCart;

public readonly struct CartResource
{
    public readonly string? Id { get; init; }
    public readonly string? ProductId { get; init; }
    public readonly int Quantity { get; init; }
    public readonly DateOnly CreatedAt { get; init; }

    public CartResource(CartDTO _)
    {
        Id = _.Id;
        ProductId = _.ProductId;
        Quantity = _.Quantity;
        CreatedAt = DateOnly.FromDateTime(_.CreatedAt!.Value);
    }

    public static IEnumerable<CartResource> ToArray(
        IEnumerable<CartDTO?> array)
    {
        var carts = new List<CartResource>();

        foreach (var dto in array)
            if (dto != null) carts.Add(new CartResource(dto));

        return carts;
    }
}