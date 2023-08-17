namespace ECommerce.Modules.Sales;

public interface ISalesRepository
{
    public Task<IEnumerable<SalesDTO?>> FindMany(SalesQueryDTO query);

    public Task<SalesDTO?> FindById(string id);

    public Task Register(SalesCreateDTO dto);

    public Task Update(SalesDTO dto);

    public Task Remove(SalesDTO dto);
}
