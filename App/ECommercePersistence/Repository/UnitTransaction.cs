using ECommerceApplication.Contract;
using ECommercePersistence.Context;

namespace ECommercePersistence.Repository;

public sealed class UnitTransaction(DatabaseContext context) : IUnitTransaction
{
    private readonly DatabaseContext _context = context;

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
