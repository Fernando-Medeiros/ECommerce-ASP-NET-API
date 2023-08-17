namespace ECommerce.Modules.Category;

using ECommerce.Modules.Product;

public interface ICategoryRepository
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