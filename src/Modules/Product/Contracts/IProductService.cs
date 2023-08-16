namespace ECommerce.Modules.Product;

public interface IProductService
{
    public Task<IEnumerable<ProductDTO>> FindMany(ProductQueryDTO query);

    public Task<ProductDTO> FindOne(string? id = null, string? name = null);

    public Task Register(ProductDTO product);

    public Task Update(ProductDTO product);

    public Task Remove(ProductDTO product);
}
