namespace ECommerce.Modules.Category;

using ECommerce.Context;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly DatabaseContext _context;
    public CategoryRepository(DatabaseContext context) => _context = context;

    public async Task<IEnumerable<Category>> FindMany(CategoryQueryDTO query)
    {
        var categoryEntities = await _context.Categories
            .AsNoTracking()
            .Take(query.Limit)
            .OrderBy(c => c.Id)
            .Skip(query.Skip > 0 ? query.Skip : 0)
            .ToListAsync();

        if (query.Name)
            categoryEntities = categoryEntities.OrderBy(c => c.Name).ToList();

        return categoryEntities;
    }

    public async Task<ICollection<Product>?> FindProducts(int id)
    {
        var category = await _context.Categories
            .Include(c => c.Products)
            .SingleOrDefaultAsync(c => c.Id == id);

        return category?.Products;
    }

    public async Task<Category?> FindOne(int? id, string? name)
    {
        if (id != null)
            return await _context.Categories
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

        else if (name != null)
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name);

        return null;
    }

    public async Task Create(Category category)
    {
        _context.Categories.Add(category);

        await _context.SaveChangesAsync();
    }

    public async Task Update(Category category)
    {
        _context.Categories.Entry(category).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(Category category)
    {
        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();
    }
}