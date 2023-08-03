namespace ECommerce_ASP_NET_API.Modules.Cart;

using ECommerce_ASP_NET_API.Models;

public interface ICartRepository
{
    public Task<Cart?> FindOne(int cartId, string customerId);

    public Task Create(Cart cart);

    public Task Update(Cart cart);

    public Task Remove(Cart cart);
}
