namespace ECommerce.Modules.Sales;

public interface ISalesService
{
    public Task<IEnumerable<SalesDTO?>> FindMany(SalesQueryDTO query);

    public Task<SalesDTO> FindById(string id);

    public Task Register(SalesCreateDTO dto);

    public Task Remove(string id);
}
