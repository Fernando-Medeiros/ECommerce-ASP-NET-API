namespace ECommerce.Modules.Cart;

public readonly struct CartCreateDTO
{
    public readonly string? Id;
    public readonly string? CustomerId;
    public readonly string? ProductId;
    public readonly int Quantity;
    public readonly DateTime CreatedAt;

    public CartCreateDTO(
        string? customerId,
        string? productId,
        int quantity)
    {
        Id = Guid.NewGuid().ToString();
        CustomerId = customerId;
        ProductId = productId;
        Quantity = quantity;
        CreatedAt = DateTime.UtcNow;
    }

    public static CartCreateDTO ExtractProperties(
        CartCreateRequest req, string customerId)
    {
        return new(
            customerId: customerId,
            productId: req.ProductId,
            quantity: req.Quantity
        );
    }
}
