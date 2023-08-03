namespace ECommerce.Modules.Category;

using ECommerce.Modules.Product;

public interface ICategoryService
{
    public Task<IEnumerable<CategoryDTO>> FindMany(CategoryQueryDTO query);

    public Task<IEnumerable<ProductDTO>> FindProducts(int id);

    public Task<CategoryDTO> FindOne(int id);

    public Task<CategoryDTO> Register(CategoryDTO category);

    public Task Update(CategoryDTO category);

    public Task Remove(CategoryDTO category);
}