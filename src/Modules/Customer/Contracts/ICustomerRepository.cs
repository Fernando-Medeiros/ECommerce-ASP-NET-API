namespace ECommerce.Modules.Customer;

using ECommerce.Modules.Cart;

public interface ICustomerRepository
{
    public Task<IEnumerable<CartDTO?>> FindCarts(string id);

    public Task<CustomerDTO?> Find(string? id = null, string? email = null);

    public Task<CustomerDTO> Register(CustomerCreateDTO dto);

    public Task Update(CustomerDTO dto);

    public Task Remove(CustomerDTO dto);
}