namespace ECommerce.Modules.Cart;

public readonly struct CartUpdateDTO
{
    public readonly string? Id;
    public readonly string? CustomerId;
    public readonly int? Quantity;
    public readonly DateTime UpdatedAt;

    public CartUpdateDTO(
        string? id,
        string? customerId,
        int? quantity)
    {
        Id = id;
        CustomerId = customerId;
        Quantity = quantity;
        UpdatedAt = DateTime.UtcNow;
    }

    public static CartUpdateDTO ExtractProperties(
        CartUpdateRequest req, string cartId, string customerId)
    {
        return new(
            id: cartId,
            customerId: customerId,
            quantity: req.Quantity
        );
    }

    public readonly void UpdateProperties(ref CartDTO cart)
    {
        if (Quantity != null) cart.Quantity = (int)Quantity;

        cart.UpdatedAt = UpdatedAt;
    }
}
