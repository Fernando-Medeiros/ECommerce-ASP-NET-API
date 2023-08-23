namespace ECommerce.Modules.CustomerCart;

public interface ICartRepository
{
    public Task<IEnumerable<CartDTO?>> FindCarts(string id);

    public Task<CartDTO?> FindOne(string cartId, string customerId);

    public Task Register(CartCreateDTO dto);

    public Task Update(CartDTO dto);

    public Task Remove(CartDTO dto);
}
