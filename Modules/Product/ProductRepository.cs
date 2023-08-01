namespace ECommerce_ASP_NET_API.Modules.Product;

using ECommerce_ASP_NET_API.Context;
using ECommerce_ASP_NET_API.Models;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseContext _context;
    public ProductRepository(DatabaseContext context) => _context = context;

    public async Task<IEnumerable<Product>> FindMany(ProductQueryDTO query)
    {
        var productEntities = await _context.Products
            .AsNoTracking()
            .Take(query.Limit)
            .OrderBy(c => c.Id)
            .Skip(query.Skip > 0 ? query.Skip : 0)
            .ToListAsync();

        if (query.Name)
            productEntities = productEntities.OrderBy(p => p.Name).ToList();

        else if (query.Price)
            productEntities = productEntities.OrderBy(p => p.Price).ToList();

        return productEntities;
    }

    public async Task<Product?> FindOne(int? id = null, string? name = null)
    {
        if (id != null)
            return await _context.Products
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);

        else if (name != null)
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Name == name);

        return null;
    }

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Products.Entry(product).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> Remove(Product product)
    {
        _context.Remove(product);

        await _context.SaveChangesAsync();

        return product;
    }
}