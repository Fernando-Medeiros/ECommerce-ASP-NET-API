namespace ECommerce.Modules.Customer;

using AutoMapper;
using ECommerce.Context;
using ECommerce.Models;
using ECommerce.Modules.CustomerCart;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public CustomerRepository(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CartDTO?>> FindCarts(string id)
    {
        var customer = await _context.Customers
            .Include(c => c.Carts)
            .SingleOrDefaultAsync(c => c.Id == id);

        return customer?.Carts == null
            ? new List<CartDTO>()
            : _mapper.Map<IEnumerable<CartDTO>>(customer?.Carts);
    }

    public async Task<CustomerDTO?> Find(string? id, string? email)
    {
        Customer? result = null;

        if (id != null)
            result = await _context.Customers
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

        else if (email != null)
            result = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email);

        return result == null ? null : _mapper.Map<CustomerDTO>(result);
    }

    public async Task<CustomerDTO> Register(CustomerCreateDTO dto)
    {
        var customerEntity = _mapper.Map<Customer>(dto);

        _context.Customers.Add(customerEntity);

        await _context.SaveChangesAsync();

        return _mapper.Map<CustomerDTO>(customerEntity);
    }

    public async Task Update(CustomerDTO dto)
    {
        var customerEntity = _mapper.Map<Customer>(dto);

        _context.Customers.Entry(customerEntity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(CustomerDTO dto)
    {
        var customerEntity = _mapper.Map<Customer>(dto);

        _context.Customers.Remove(customerEntity);

        await _context.SaveChangesAsync();
    }
}