namespace ECommerce.Modules.Customer;

using ECommerce.Modules.Cart;

public interface ICustomerService
{
    public Task<IEnumerable<CartDTO>> FindCarts(string id);

    public Task<CustomerDTO> FindById(string id);

    public Task Register(CustomerDTO customer);

    public Task Update(CustomerDTO customer);

    public Task Remove(CustomerDTO customer);
}