namespace ECommerce_ASP_NET_API.Modules.Session;

using ECommerce_ASP_NET_API.Models;

public interface ISessionRepository
{
    public Task<Customer?> FindCustomer(string email);
}
