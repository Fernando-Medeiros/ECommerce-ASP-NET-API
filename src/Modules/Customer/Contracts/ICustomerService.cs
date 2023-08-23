using ECommerce.Modules.CustomerCart;

namespace ECommerce.Modules.Customer;

public interface ICustomerService
{
    public Task<IEnumerable<CartDTO?>> FindCarts(string id);

    public Task<CustomerDTO> FindById(string id);

    public Task Register(CustomerCreateDTO dto);

    public Task Update(CustomerUpdateDTO dto);

    public Task Remove(string id);
}