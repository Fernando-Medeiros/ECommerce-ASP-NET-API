namespace ECommerce_ASP_NET_API.Modules.Session;

using ECommerce_ASP_NET_API.Context;
using ECommerce_ASP_NET_API.Models;
using Microsoft.EntityFrameworkCore;

public class SessionRepository : ISessionRepository
{
    private readonly DatabaseContext _context;
    public SessionRepository(DatabaseContext context) => _context = context;

    public async Task<Customer?> FindCustomer(string email)
    {
        return await _context.Customers.SingleOrDefaultAsync(c => c.Email == email);
    }
}
