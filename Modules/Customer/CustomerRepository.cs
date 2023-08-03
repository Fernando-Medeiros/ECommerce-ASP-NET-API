namespace ECommerce.Modules.Customer;

using Microsoft.EntityFrameworkCore;
using ECommerce.Context;
using ECommerce.Models;
using System.Collections.Generic;

public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;
    public CustomerRepository(DatabaseContext context) => _context = context;

    public async Task<ICollection<Cart>?> FindCarts(string? id)
    {
        var customer = await _context.Customers
            .Include(c => c.Carts)
            .SingleOrDefaultAsync(c => c.Id == id);

        return customer?.Carts;
    }

    public async Task<Customer?> Find(string? id, string? email)
    {
        if (id != null)
            return await _context.Customers
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

        else if (email != null)
            return await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email);

        return null;
    }

    public async Task Create(Customer customer)
    {
        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();
    }

    public async Task Update(Customer customer)
    {
        _context.Customers.Entry(customer).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(Customer customer)
    {
        _context.Customers.Remove(customer);

        await _context.SaveChangesAsync();
    }
}