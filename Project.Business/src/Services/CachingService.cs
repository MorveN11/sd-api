using Microsoft.Extensions.Caching.Hybrid;
using Project.DataAccess.Services;

namespace Project.Business.Services;

public class CachingService(HybridCache hybridCache) : ICachingService
{
    public async Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, ValueTask<T>> factory,
        IEnumerable<string> tags,
        CancellationToken cancellationToken = default
    )
    {
        T result = await hybridCache.GetOrCreateAsync(
            key,
            factory,
            tags: tags,
            cancellationToken: cancellationToken
        );

        return result;
    }

    public async Task EvictByTagAsync(string tag, CancellationToken cancellationToken = default)
    {
        await hybridCache.RemoveByTagAsync(tag, cancellationToken);
    }
}
