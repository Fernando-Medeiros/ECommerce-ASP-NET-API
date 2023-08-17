namespace ECommerce.Modules.Sales;

using AutoMapper;
using ECommerce.Context;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

public class SalesRepository : ISalesRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public SalesRepository(
        DatabaseContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SalesDTO?>> FindMany(SalesQueryDTO query)
    {
        List<Sales>? sales = await _context.Sales
            .AsNoTracking()
            .Take(query.Limit)
            .OrderBy(c => c.Id)
            .Skip(query.Skip > 0 ? query.Skip : 0)
            .ToListAsync();

        if (query.Price)
            sales = sales.OrderBy(p => p.Price).ToList();

        return _mapper.Map<IEnumerable<SalesDTO>>(sales);
    }

    public async Task<SalesDTO?> FindById(string id)
    {
        Sales? sales = await _context.Sales
            .AsNoTracking()
            .SingleOrDefaultAsync(s => s.Id == id);

        return sales == null
        ? null
        : _mapper.Map<SalesDTO>(sales);
    }

    public async Task Register(SalesCreateDTO dto)
    {
        Sales sales = _mapper.Map<Sales>(dto);

        _context.Add(sales);

        await _context.SaveChangesAsync();
    }

    public async Task Update(SalesDTO dto)
    {
        Sales sales = _mapper.Map<Sales>(dto);

        _context.Update(sales).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(SalesDTO dto)
    {
        Sales sales = _mapper.Map<Sales>(dto);

        _context.Remove(sales);

        await _context.SaveChangesAsync();
    }
}
