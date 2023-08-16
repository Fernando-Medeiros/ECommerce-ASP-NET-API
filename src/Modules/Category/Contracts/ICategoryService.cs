namespace ECommerce.Modules.Category;

using ECommerce.Modules.Product;

public interface ICategoryService
{
    public Task<IEnumerable<CategoryDTO>> FindMany(CategoryQueryDTO query);

    public Task<IEnumerable<ProductDTO>> FindProducts(string id);

    public Task<CategoryDTO> FindOne(string? id = null, string? name = null);

    public Task Register(CategoryDTO category);

    public Task Update(CategoryDTO category);

    public Task Remove(CategoryDTO category);
}