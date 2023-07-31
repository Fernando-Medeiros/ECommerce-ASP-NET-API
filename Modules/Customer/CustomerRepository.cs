namespace ECommerce_ASP_NET_API.Modules.Customer;

using Microsoft.EntityFrameworkCore;
using ECommerce_ASP_NET_API.Context;
using ECommerce_ASP_NET_API.Models;
using ECommerce_ASP_NET_API.Modules.Customer.Contracts;


public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;
    public CustomerRepository(DatabaseContext context) => _context = context;

    public async Task<Customer?> Find(string? id, string? email)
    {
        if (id != null)
            return await _context.Customers
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

        return await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Customer> Create(Customer customer)
    {
        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer> Update(Customer customer)
    {
        _context.Customers.Entry(customer).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer> Remove(Customer customer)
    {
        _context.Customers.Remove(customer);

        await _context.SaveChangesAsync();

        return customer;
    }
}