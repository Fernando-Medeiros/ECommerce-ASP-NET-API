namespace ECommerce_ASP_NET_API.Modules.Category;

using ECommerce_ASP_NET_API.Models;

public interface ICategoryRepository
{
    public Task<IEnumerable<Category>> FindMany(CategoryQueryDTO query);

    public Task<Category?> FindOne(int? id = null, string? name = null);

    public Task<Category> Create(Category category);

    public Task<Category> Update(Category category);

    public Task<Category> Remove(Category category);
}