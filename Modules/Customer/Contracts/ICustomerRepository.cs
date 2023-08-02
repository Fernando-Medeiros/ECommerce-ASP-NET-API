namespace ECommerce_ASP_NET_API.Modules.Customer;

using ECommerce_ASP_NET_API.Models;

public interface ICustomerRepository
{
    public Task<Customer?> Find(string? id = null, string? email = null);

    public Task Create(Customer customer);

    public Task Update(Customer customer);

    public Task Remove(Customer customer);
}