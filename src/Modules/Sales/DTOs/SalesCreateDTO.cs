namespace ECommerce.Modules.Sales;

public readonly struct SalesCreateDTO
{
    public readonly string? Id;
    public readonly string? CustomerId;
    public readonly string? ProductId;
    public readonly decimal Price;
    public readonly int Quantity;
    public readonly DateTime CreatedAt;

    public SalesCreateDTO(
        string? customerId,
        string? productId,
        decimal price,
        int quantity)
    {
        Id = Guid.NewGuid().ToString();
        CustomerId = customerId;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
        CreatedAt = DateTime.UtcNow;
    }

    public static SalesCreateDTO ExtractProperties(
        SalesCreateRequest req)
    {
        return new(
            customerId: req.CustomerId,
            productId: req.ProductId,
            price: req.Price,
            quantity: req.Quantity);
    }
}
