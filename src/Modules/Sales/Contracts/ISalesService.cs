namespace ECommerce.Modules.Sales;

using ECommerce.Modules.Sales.DTOs;

public interface ISalesService
{
    public Task<IEnumerable<SalesDTO>> FindMany(SalesQueryDTO query);

    public Task<SalesDTO> FindOne(SalesQueryFindOneDTO query);

    public Task<SalesDTO> FindById(string id);

    public Task Register(SalesDTO sales);

    public Task Remove(SalesDTO sales);
}
