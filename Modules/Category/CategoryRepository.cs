namespace ECommerce_ASP_NET_API.Modules.Category;

using ECommerce_ASP_NET_API.Context;
using ECommerce_ASP_NET_API.Models;
using ECommerce_ASP_NET_API.Modules.Category.Contracts;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly DatabaseContext _context;
    public CategoryRepository(DatabaseContext context) => _context = context;

    public IQueryable<Category> Find()
    {
        return _context.Categories;
    }

    public async Task<Category> Create(Category category)
    {
        _context.Categories.Add(category);

        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _context.Categories.Entry(category).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> Remove(Category category)
    {
        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();

        return category;
    }
}