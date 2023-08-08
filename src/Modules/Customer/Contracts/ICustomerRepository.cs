namespace ECommerce.Modules.Customer;

using ECommerce.Models;

public interface ICustomerRepository
{
    public Task<ICollection<Cart>?> FindCarts(string? id = null);

    public Task<Customer?> Find(string? id = null, string? email = null);

    public Task Create(Customer customer);

    public Task Update(Customer customer);

    public Task Remove(Customer customer);
}