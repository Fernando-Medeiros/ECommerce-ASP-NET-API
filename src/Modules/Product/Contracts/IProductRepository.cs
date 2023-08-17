namespace ECommerce.Modules.Product;

public interface IProductRepository
{
    public Task<IEnumerable<ProductDTO?>> FindMany(ProductQueryDTO query);

    public Task<ProductDTO?> FindOne(
        string? id = null,
        string? name = null);

    public Task Register(ProductCreateDTO dto);

    public Task Update(ProductDTO dto);

    public Task Remove(ProductDTO dto);
}

