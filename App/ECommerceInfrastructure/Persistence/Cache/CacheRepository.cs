using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace ECommerceInfrastructure.Persistence.Cache;

public abstract class CacheRepository<TExpected>
{
    readonly JsonSerializerOptions serializerOptions = new() { PropertyNameCaseInsensitive = true };

    public abstract Task<TExpected?> FindAsync(
        string key,
        CancellationToken cancellationToken);

    public abstract Task<bool> InsertAsync(
        string key,
        TExpected value,
        CancellationToken cancellationToken);

    public abstract Task<bool> InsertAsync(
        List<Tuple<string, TExpected>> tuples,
        CancellationToken cancellationToken);

    public abstract Task<bool> RemoveAsync(
        string key,
        CancellationToken cancellationToken);

    public abstract Task<bool> RemoveAsync(
        List<string> keys,
        CancellationToken cancellationToken);


    public async Task<T?> DeserializeObject<T>(byte[] bytes)
    {
        return await Task.Run(() =>
        {
            string stringObject = Encoding.UTF8.GetString(bytes);

            return JsonSerializer.Deserialize<T?>(stringObject, serializerOptions);
        });
    }

    public async Task<byte[]> SerializeObject<T>(T instance)
    {
        return await Task.Run(() =>
        {
            string stringObject = JsonSerializer.Serialize(instance, serializerOptions);

            return Encoding.UTF8.GetBytes(stringObject);
        });
    }

    public static DistributedCacheEntryOptions CacheEntryOptions(
        int inactiveMinutes = 5,
        int lifeTimeMinutes = 10)
    {
        return new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(DateTime.Now.AddMinutes(lifeTimeMinutes))
            .SetSlidingExpiration(TimeSpan.FromMinutes(inactiveMinutes));
    }
}
