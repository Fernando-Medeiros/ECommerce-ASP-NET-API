namespace ECommerce.Modules.Product;

using AutoMapper;
using ECommerce.Context;
using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public ProductRepository(
        DatabaseContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO?>> FindMany(ProductQueryDTO query)
    {
        var products = await _context.Products
            .AsNoTracking()
            .Take(query.Limit)
            .OrderBy(c => c.Id)
            .Skip(query.Skip > 0 ? query.Skip : 0)
            .ToListAsync();

        if (query.Name)
            products = products.OrderBy(p => p.Name).ToList();

        else if (query.Price)
            products = products.OrderBy(p => p.Price).ToList();

        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO?> FindOne(string? id, string? name)
    {
        Product? product = null;

        if (id != null)
            product = await _context.Products
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);

        else if (name != null)
            product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Name == name);

        return product == null
            ? null
            : _mapper.Map<ProductDTO>(product);
    }

    public async Task Register(ProductCreateDTO dto)
    {
        var productEntity = _mapper.Map<Product>(dto);

        _context.Products.Add(productEntity);

        await _context.SaveChangesAsync();
    }

    public async Task Update(ProductDTO dto)
    {
        var productEntity = _mapper.Map<Product>(dto);

        _context.Products.Entry(productEntity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(ProductDTO dto)
    {
        var productEntity = _mapper.Map<Product>(dto);

        _context.Remove(productEntity);

        await _context.SaveChangesAsync();
    }
}