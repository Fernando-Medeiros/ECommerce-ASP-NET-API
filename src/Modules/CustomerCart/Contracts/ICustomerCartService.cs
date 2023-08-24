namespace ECommerce.Modules.CustomerCart;

public interface ICustomerCartService
{
    public Task<IEnumerable<CartDTO?>> FindCarts(string id);

    public Task<CartDTO> FindOne(string cartId, string customerId);

    public Task Register(CartCreateDTO dto);

    public Task Update(CartUpdateDTO dto);

    public Task Remove(string cartId, string customerId);
}
