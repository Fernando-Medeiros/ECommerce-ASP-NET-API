namespace ECommerce.Modules.Category;

using ECommerce.Models;

public interface ICategoryRepository
{
    public Task<IEnumerable<Category>> FindMany(CategoryQueryDTO query);

    public Task<ICollection<Product>?> FindProducts(string id);

    public Task<Category?> FindOne(string? id = null, string? name = null);

    public Task Create(Category category);

    public Task Update(Category category);

    public Task Remove(Category category);
}