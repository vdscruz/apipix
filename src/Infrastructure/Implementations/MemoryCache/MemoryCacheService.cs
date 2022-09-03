using Application.Interfaces.MemoryCache;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Implementations.MemoryCache;

public sealed class MemoryCacheService<T>:IMemoryCacheService<T>
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Task<T> GetAsync(string key)
    {
        _memoryCache.TryGetValue(key, out T entry);
        return Task.FromResult<T>(entry);
    }

    public void Set(string key, T entry, MemoryCacheEntryOptions options = null)
        => _memoryCache.Set(key, entry, options);

    public void Remove(string key)
        => _memoryCache.Remove(key);
}