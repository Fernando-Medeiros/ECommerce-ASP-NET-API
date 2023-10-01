using ECommerceApplication.Contracts;
using ECommerceInfrastructure.Persistence.Contexts;

namespace ECommerceInfrastructure.Persistence.Repositories;

public sealed class UnitTransactionWork : IUnitTransactionWork
{
    private readonly DatabaseContext _context;

    public UnitTransactionWork(DatabaseContext context) => _context = context;

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
