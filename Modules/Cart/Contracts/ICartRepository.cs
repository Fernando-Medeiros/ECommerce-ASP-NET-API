namespace ECommerce_ASP_NET_API.Modules.Cart;

using ECommerce_ASP_NET_API.Models;

public interface ICartRepository
{
    public Task<Cart?> FindOne(int? id);

    public Task<Cart> Create(Cart cart);

    public Task<Cart> Update(Cart cart);

    public Task<Cart> Remove(Cart cart);
}
