namespace ECommerce_ASP_NET_API.Modules.Product;

public interface IProductService
{
    public Task<IEnumerable<ProductDTO>> FindMany(ProductQueryDTO query);

    public Task<ProductDTO> FindOne(int? id = null, string? name = null);

    public Task<ProductDTO> Register(ProductDTO product);

    public Task Update(ProductDTO product);

    public Task Remove(ProductDTO product);
}
