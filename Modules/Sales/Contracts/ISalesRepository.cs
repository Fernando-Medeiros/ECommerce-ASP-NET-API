namespace ECommerce.Modules.Sales;

using ECommerce.Models;

public interface ISalesRepository
{
    public Task<Sales?> Find(int id);

    public Task Register(Sales sales);

    public Task Update(Sales sales);

    public Task Remove(Sales sales);
}
