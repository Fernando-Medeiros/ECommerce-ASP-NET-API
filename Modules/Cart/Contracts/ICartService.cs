namespace ECommerce_ASP_NET_API.Modules.Cart;

public interface ICartService
{
    public Task<CartDTO?> FindOne(int? id);

    public Task<CartDTO> Register(CartDTO cart);

    public Task Update(CartDTO cart);

    public Task Remove(CartDTO cart);
}
