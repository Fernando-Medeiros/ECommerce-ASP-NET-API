using ECommerceApplication.Contract;
using ECommercePersistence.Contexts;

namespace ECommercePersistence.Repositories;

public sealed class UnitTransactionWork : IUnitTransaction
{
    private readonly DatabaseContext _context;

    public UnitTransactionWork(DatabaseContext context) => _context = context;

    public async Task Commit(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) return;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
