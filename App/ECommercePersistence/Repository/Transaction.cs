using ECommerceApplication.Contract;
using ECommercePersistence.Context;

namespace ECommercePersistence.Repository;

public sealed class Transaction(DatabaseContext context) : ITransaction
{
    readonly DatabaseContext _context = context;

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
