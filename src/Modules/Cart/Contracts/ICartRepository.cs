namespace ECommerce.Modules.Cart;

using ECommerce.Models;

public interface ICartRepository
{
    public Task<Cart?> FindOne(int cartId, string customerId);

    public Task Create(Cart cart);

    public Task Update(Cart cart);

    public Task Remove(Cart cart);
}
