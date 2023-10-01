using AutoMapper;
using ECommerceApplication.Contracts;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Persistence.Contexts;
using ECommerceInfrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.Persistence.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public CustomerRepository(
        DatabaseContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDTO?> FindOne(CustomerDTO dto)
    {
        Customer? result = null;

        if (dto.Id is string || dto.Email is string)
        {
            result = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    c => dto.Id is string
                    ? c.Id == dto.Id
                    : c.Email == dto.Email);
        }

        return _mapper.Map<CustomerDTO?>(result);
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
}
