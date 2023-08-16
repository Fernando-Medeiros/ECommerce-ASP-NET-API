namespace ECommerce.Modules.Cart;

public interface ICartService
{
    public Task<CartDTO> FindOne(string cartId, string customerId);

    public Task Register(CartCreateDTO dto);

    public Task Update(CartUpdateDTO dto);

    public Task Remove(string cartId, string customerId);
}
