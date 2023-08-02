namespace ECommerce_ASP_NET_API.Modules.Sales;

using ECommerce_ASP_NET_API.Models;

public interface ISalesRepository
{
    public Task<Sales?> Find(int? id);

    public Task Create(Sales sales);

    public Task Update(Sales sales);

    public Task Remove(Sales sales);
}
