using System.Linq.Expressions;
using AutoMapper;
using ECommerceApplication.Contract;
using ECommerceDomain.DTO;
using ECommercePersistence.Cache;
using ECommercePersistence.Contexts;
using ECommercePersistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly CustomerCacheRepository _cache;
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public CustomerRepository(
        CustomerCacheRepository cache,
        DatabaseContext context,
        IMapper mapper)
    {
        _cache = cache;
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDTO?> Find(CustomerDTO request, CancellationToken cancellationToken)
    {
        return request switch
        {
            { Id: string id } => await FindByAsync(id, c => c.Id == id, cancellationToken),

            { Email: string email } => await FindByAsync(email, c => c.Email == email, cancellationToken),
            _ => null
        };
    }

    public void Register(CustomerDTO customer)
    {
        var entity = _mapper.Map<Customer>(customer);

        _context.Customers.Add(entity);
    }

    public void Update(CustomerDTO customer)
    {
        var entity = _mapper.Map<Customer>(customer);

        _context.Customers.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(CustomerDTO customer)
    {
        var entity = _mapper.Map<Customer>(customer);

        _context.Customers.Remove(entity);
    }

    private async Task<CustomerDTO?> FindByAsync(
        string? value,
        Expression<Func<Customer, bool>> predicate,
        CancellationToken cancellationToken)
    {
        if (value is null) return null;

        Customer? customer = await _cache.FindAsync(value, cancellationToken);

        if (customer is null)
        {
            customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate, cancellationToken);

            if (customer is Customer)
            {
                await _cache.InsertAsync(value, customer, cancellationToken);
            }
        }
        return _mapper.Map<CustomerDTO?>(customer);
    }
}
