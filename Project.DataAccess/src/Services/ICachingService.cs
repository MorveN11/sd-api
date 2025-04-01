namespace Project.DataAccess.Services;

public interface ICachingService
{
    Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, ValueTask<T>> factory,
        IEnumerable<string> tags,
        CancellationToken cancellationToken = default
    );

    Task EvictByTagAsync(string tag, CancellationToken cancellationToken = default);
}
