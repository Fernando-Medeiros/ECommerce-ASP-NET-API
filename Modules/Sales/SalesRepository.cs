namespace ECommerce.Modules.Sales;

using ECommerce.Context;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

public class SalesRepository : ISalesRepository
{
    private readonly DatabaseContext _context;
    public SalesRepository(DatabaseContext context) => _context = context;

    public async Task<Sales?> Find(int? id)
    {
        if (id != null)
            return await _context.Sales
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);

        return null;
    }

    public async Task Create(Sales sales)
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
