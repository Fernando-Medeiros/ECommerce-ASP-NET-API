namespace ECommerce.Modules.Category;

using AutoMapper;
using ECommerce.Context;
using ECommerce.Models;
using ECommerce.Modules.Product;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public CategoryRepository(
        DatabaseContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO?>> FindMany(CategoryQueryDTO query)
    {
        var categories = await _context.Categories
            .AsNoTracking()
            .Take(query.Limit)
            .OrderBy(c => c.Id)
            .Skip(query.Skip > 0 ? query.Skip : 0)
            .ToListAsync();

        if (query.Name)
            categories = categories.OrderBy(c => c.Name).ToList();

        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<IEnumerable<ProductDTO?>> FindProducts(string productId)
    {
        var category = await _context.Categories
            .Include(c => c.Products)
            .SingleOrDefaultAsync(c => c.Id == productId);

        return _mapper.Map<IEnumerable<ProductDTO>>(category?.Products);

    }

    public async Task<CategoryDTO?> FindOne(string? categoryId, string? name)
    {
        Category? category = null;

        if (categoryId != null)
            category = await _context.Categories
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == categoryId);

        else if (name != null)
            category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name);

        return category == null
            ? null
            : _mapper.Map<CategoryDTO>(category);
    }

    public async Task Create(CategoryCreateDTO dto)
    {
        var categoryEntity = _mapper.Map<Category>(dto);

        _context.Categories.Add(categoryEntity);

        await _context.SaveChangesAsync();
    }

    public async Task Update(CategoryDTO dto)
    {
        var categoryEntity = _mapper.Map<Category>(dto);

        _context.Categories.Entry(categoryEntity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(CategoryDTO dto)
    {
        var categoryEntity = _mapper.Map<Category>(dto);

        _context.Categories.Remove(categoryEntity);

        await _context.SaveChangesAsync();
    }
}