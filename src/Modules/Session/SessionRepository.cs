namespace ECommerce.Modules.Session;

using AutoMapper;
using ECommerce.Context;
using ECommerce.Modules.Customer;
using Microsoft.EntityFrameworkCore;

public class SessionRepository : ISessionRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public SessionRepository(
        DatabaseContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDTO?> FindCustomer(string email)
    {
        var customer = await _context.Customers
            .SingleOrDefaultAsync(c => c.Email == email);

        return customer == null
        ? null
        : _mapper.Map<CustomerDTO>(customer);
    }
}
