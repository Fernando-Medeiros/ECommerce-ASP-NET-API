namespace ECommerce_ASP_NET_API.Modules.Category.Contracts;

using ECommerce_ASP_NET_API.Models;

public interface ICategoryRepository
{
    public IQueryable<Category> Find();

    public Task<Category> Create(Category category);

    public Task<Category> Update(Category category);

    public Task<Category> Remove(Category category);
}