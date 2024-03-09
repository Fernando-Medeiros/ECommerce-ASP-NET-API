using ECommercePersistence.Model;
using Microsoft.Extensions.Caching.Distributed;

namespace ECommercePersistence.Cache;

public sealed class CustomerCacheRepository(IDistributedCache distributedCache)
    : CacheRepository<Customer>
{
    private readonly IDistributedCache _cache = distributedCache;

    public override async Task<Customer?> FindAsync(
        string key,
        CancellationToken cancellationToken)
    {
        byte[]? result = await _cache.GetAsync(key, cancellationToken);

        return result is byte[]? await DeserializeObject<Customer?>(result) : null;
    }

    public override async Task<bool> InsertAsync(
        string key,
        Customer value,
        CancellationToken cancellationToken)
    {
        byte[] serializeValue = await SerializeObject(value);

        await _cache.SetAsync(
            key,
            serializeValue,
            CacheEntryOptions(inactiveMinutes: 5, lifeTimeMinutes: 10),
            cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }

    public override async Task<bool> InsertAsync(
        List<Tuple<string, Customer>> tuples,
        CancellationToken cancellationToken)
    {
        var tasks = tuples.Select(t => InsertAsync(t.Item1, t.Item2, cancellationToken));

        await Task.WhenAll(tasks);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }

    public override async Task<bool> RemoveAsync(
        string key,
        CancellationToken cancellationToken)
    {
        await _cache.RemoveAsync(key, cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }

    public override async Task<bool> RemoveAsync(
        List<string> keys,
        CancellationToken cancellationToken)
    {
        var tasks = keys.Select(key => RemoveAsync(key, cancellationToken));

        await Task.WhenAll(tasks);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
