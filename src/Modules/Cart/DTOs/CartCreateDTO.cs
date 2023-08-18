namespace ECommerce.Modules.Cart;

public struct CartCreateDTO
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }

    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }

    public static CartCreateDTO ExtractProperties(
        CartCreateRequest _, string customerId)
    {
        return new()
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = customerId,
            ProductId = _.ProductId,
            Quantity = _.Quantity,
            CreatedAt = DateTime.UtcNow
        };
    }
}
