namespace ECommerce.Modules.Customer;

using ECommerce.Modules.Cart;

public interface ICustomerService
{
    public Task<IEnumerable<CartDTO?>> FindCarts(string id);

    public Task<CustomerDTO> FindById(string id);

    public Task Register(CustomerCreateDTO dto);

    public Task Update(CustomerUpdateDTO dto);

    public Task Remove(string id);
}