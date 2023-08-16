namespace ECommerce.Modules.Cart;

public struct CartUpdateDTO
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }

    public int? Quantity { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public static CartUpdateDTO ExtractProprieties(
        CartUpdateRequest _, string cartId, string customerId)
    {
        return new()
        {
            Id = cartId,
            CustomerId = customerId,
            Quantity = _.Quantity,
        };
    }

    public readonly void UpdateProperties(ref CartDTO cart)
    {
        if (Quantity != null) cart.Quantity = (int)Quantity;

        cart.UpdatedAt = DateTime.UtcNow;
    }
}
