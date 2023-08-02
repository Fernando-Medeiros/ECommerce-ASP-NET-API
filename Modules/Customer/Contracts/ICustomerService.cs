namespace ECommerce_ASP_NET_API.Modules.Customer;

using ECommerce_ASP_NET_API.Modules.Cart;

public interface ICustomerService
{
    public Task<IEnumerable<CartDTO>> FindCarts(string id);

    public Task<CustomerDTO> FindById(string id);

    public Task<CustomerDTO> Register(CustomerDTO customer);

    public Task Update(CustomerDTO customer);

    public Task Remove(CustomerDTO customer);
}