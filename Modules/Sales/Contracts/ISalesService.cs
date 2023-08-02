namespace ECommerce_ASP_NET_API.Modules.Sales;

public interface ISalesService
{
    public Task<SalesDTO> Find(int? id);

    public Task Register(SalesDTO sales);

    public Task Remove(SalesDTO sales);
}
