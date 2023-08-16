namespace ECommerce.Modules.Sales;

using ECommerce.Models;
using ECommerce.Modules.Sales.DTOs;

public interface ISalesRepository
{
    public Task<IEnumerable<Sales>> FindMany(SalesQueryDTO query);

    public Task<Sales?> FindOne(SalesQueryFindOneDTO query);

    public Task<Sales?> FindById(string id);

    public Task Register(Sales sales);

    public Task Update(Sales sales);

    public Task Remove(Sales sales);
}
