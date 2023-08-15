namespace ECommerce.Modules.Customer;

using Microsoft.EntityFrameworkCore;
using ECommerce.Context;
using ECommerce.Models;
using System.Collections.Generic;
using AutoMapper;
using ECommerce.Modules.Cart;

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

    public async Task Create(CustomerCreateDTO dto)
    {
        var customerEntity = _mapper.Map<Customer>(dto);

        _context.Customers.Add(customerEntity);

        await _context.SaveChangesAsync();
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