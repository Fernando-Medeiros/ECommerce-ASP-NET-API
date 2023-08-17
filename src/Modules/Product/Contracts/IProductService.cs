namespace ECommerce.Modules.Product;

public interface IProductService
{
    public Task<IEnumerable<ProductDTO?>> FindMany(ProductQueryDTO query);

    public Task<ProductDTO> FindOne(
        string? id = null,
        string? name = null);

    public Task Register(ProductCreateDTO dto);

    public Task Update(ProductUpdateDTO dto);

    public Task Remove(string id);
}
