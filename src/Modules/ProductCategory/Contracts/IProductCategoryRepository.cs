namespace ECommerce.Modules.ProductCategory;

using ECommerce.Modules.Product;

public interface IProductCategoryRepository
{
    public Task<IEnumerable<CategoryDTO?>> FindMany(CategoryQueryDTO query);

    public Task<IEnumerable<ProductDTO?>> FindProducts(string id);

    public Task<CategoryDTO?> FindOne(
        string? id = null,
        string? name = null);

    public Task Create(CategoryCreateDTO dto);

    public Task Update(CategoryDTO dto);

    public Task Remove(CategoryDTO dto);
}