namespace ECommerce.Modules.Sales;

public struct SalesCreateDTO
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }

    public static SalesCreateDTO ExtractProperties(
        SalesCreateRequest _)
    {
        return new()
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = _.CustomerId,
            ProductId = _.ProductId,
            Price = _.Price,
            Quantity = _.Quantity,
            CreatedAt = DateTime.UtcNow,
        };
    }
}
