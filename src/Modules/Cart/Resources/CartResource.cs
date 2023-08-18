namespace ECommerce.Modules.Cart;

public struct CartResource
{
    public string? Id { get; set; }
    public string? ProductId { get; set; }
    public int Quantity { get; set; }
    public DateOnly CreatedAt { get; set; }

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