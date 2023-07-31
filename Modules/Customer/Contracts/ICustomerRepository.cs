namespace ECommerce_ASP_NET_API.Modules.Customer.Contracts;

using ECommerce_ASP_NET_API.Models;

public interface ICustomerRepository
{
    public Task<Customer?> Find(string? id = null, string? email = null);

    public Task<Customer> Create(Customer customer);

    public Task<Customer> Update(Customer customer);

    public Task<Customer> Remove(Customer customer);
}