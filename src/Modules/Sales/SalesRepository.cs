namespace ECommerce.Modules.Sales;

using System.Collections.Generic;
using ECommerce.Context;
using ECommerce.Models;
using ECommerce.Modules.Sales.DTOs;
using Microsoft.EntityFrameworkCore;

public class SalesRepository : ISalesRepository
{
    private readonly DatabaseContext _context;

    public SalesRepository(DatabaseContext context) => _context = context;

    public async Task<IEnumerable<Sales>> FindMany(SalesQueryDTO query)
    {
        var salesEntities = await _context.Sales
            .AsNoTracking()
            .Take(query.Limit)
            .OrderBy(c => c.Id)
            .Skip(query.Skip > 0 ? query.Skip : 0)
            .ToListAsync();

        if (query.Price)
            salesEntities = salesEntities.OrderBy(p => p.Price).ToList();

        return salesEntities;
    }

    public async Task<Sales?> FindOne(SalesQueryFindOneDTO query)
    {
        return await _context.Sales
            .AsNoTracking()
            .SingleOrDefaultAsync(s =>
                s.ProductId == query.ProductId
                &&
                s.CustomerId == query.CustomerId
                &&
                s.CreatedAt == query.CreatedAt);
    }

    public async Task<Sales?> FindById(string id)
    {
        return await _context.Sales
            .AsNoTracking()
            .SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task Register(Sales sales)
    {
        _context.Add(sales);

        await _context.SaveChangesAsync();
    }

    public async Task Update(Sales sales)
    {
        _context.Update(sales).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(Sales sales)
    {
        _context.Remove(sales);

        await _context.SaveChangesAsync();
    }
}
