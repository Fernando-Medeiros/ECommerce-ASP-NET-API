using ECommerceInfrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECommerceInfrastructure.Persistence.Cache;

public sealed class CustomerCacheSaveInterceptor : SaveChangesInterceptor
{
    private readonly CustomerCacheRepository _cache;

    public CustomerCacheSaveInterceptor(CustomerCacheRepository cache) => _cache = cache;

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        return base.SavedChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        await ExecuteCacheInterceptor(eventData, cancellationToken);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public async Task ExecuteCacheInterceptor(
        DbContextEventData eventData,
        CancellationToken cancellationToken)
    {
        await Task.WhenAll(ModifiedState(eventData, cancellationToken));

        await Task.WhenAll(DeletedState(eventData, cancellationToken));
    }

    private IEnumerable<Task> ModifiedState(
        DbContextEventData eventData,
        CancellationToken cancellationToken)
    {
        var added = Filter(EntityState.Added, eventData);

        var modified = Filter(EntityState.Modified, eventData);

        var Union = added.Union(modified).ToList();

        var tasks = Union.Select(entity =>
            _cache.InsertAsync($"{entity.Id}", entity, cancellationToken));

        return tasks;
    }

    private IEnumerable<Task> DeletedState(
        DbContextEventData eventData,
        CancellationToken cancellationToken)
    {
        var deleted = Filter(EntityState.Deleted, eventData);

        var tasks = deleted.Select((entity) =>
            _cache.RemoveAsync(new List<string>()
                {
                    $"{entity.Id}",
                    $"{entity.Email}"
                },
                cancellationToken));

        return tasks;
    }

    private static List<Customer> Filter(
        EntityState state,
        DbContextEventData eventData)
    {
        List<Customer> entities = new();

        if (eventData?.Context is DbContext)
        {
            entities.AddRange(eventData.Context.ChangeTracker.Entries<Customer>()
                    .Where(e => e.State == state)
                    .Select(e => e.Entity));
        }
        return entities;
    }
}
