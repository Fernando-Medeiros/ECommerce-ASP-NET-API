namespace ECommerce.Modules.Customer;

using AutoMapper;
using ECommerce.Context;
using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;


public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public CustomerRepository(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDTO?> Find(CustomerDTO dto)
    {
        Customer? result = null;

        if (dto.Id != null)
            result = await _context.Customers
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == dto.Id);

        else if (dto.Email != null)
            result = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == dto.Email);

        return result == null ? null : _mapper.Map<CustomerDTO>(result);
    }

    public async Task<CustomerDTO> Register(CustomerDTO customer)
    {
        var entity = _mapper.Map<Customer>(customer);

        _context.Customers.Add(entity);

        await _context.SaveChangesAsync();

        return _mapper.Map<CustomerDTO>(entity);
    }

    public async Task Update(CustomerDTO customer)
    {
        var entity = _mapper.Map<Customer>(customer);

        _context.Customers.Entry(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(CustomerDTO customer)
    {
        var entity = _mapper.Map<Customer>(customer);

        _context.Customers.Remove(entity);

        await _context.SaveChangesAsync();
    }
}