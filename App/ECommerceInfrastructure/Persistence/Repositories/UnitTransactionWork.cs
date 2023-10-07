using ECommerceApplication.Contracts;
using ECommerceInfrastructure.Persistence.Contexts;

namespace ECommerceInfrastructure.Persistence.Repositories;

public sealed class UnitTransactionWork : IUnitTransactionWork
{
    private readonly DatabaseContext _context;

    public UnitTransactionWork(DatabaseContext context) => _context = context;

    public async Task Commit(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) return;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
