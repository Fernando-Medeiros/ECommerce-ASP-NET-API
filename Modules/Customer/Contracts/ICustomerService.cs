using ECommerce_ASP_NET_API.Modules.Customer.DTOs;

namespace ECommerce_ASP_NET_API.Modules.Customer.Contracts;

public interface ICustomerService
{
    public Task<CustomerDTO> FindById(string id);

    public Task<CustomerDTO> Register(CustomerDTO customer);

    public Task Update(CustomerDTO customer);

    public Task Remove(CustomerDTO customer);
}