namespace ECommerce.Modules.Session;

using ECommerce.Models;

public interface ISessionRepository
{
    public Task<Customer?> FindCustomer(string email);
}
