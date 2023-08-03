namespace ECommerce.Modules.Cart;

public interface ICartService
{
    public Task<CartDTO> FindOne(int cartId, string customerId);

    public Task Register(CartDTO cart);

    public Task Update(CartDTO cart);

    public Task Remove(CartDTO cart);
}
