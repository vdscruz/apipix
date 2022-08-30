using Application.Interfaces.MemoryCache;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Implementations.MemoryCache;

public class MemoryCacheService<T>:ICacheService<T>
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public virtual Task<T> GetAsync(string key)
    {
        _memoryCache.TryGetValue(key, out T entry);
        return Task.FromResult<T>(entry);
    }

    public virtual void Set(string key, T entry, MemoryCacheEntryOptions options = null)
        => _memoryCache.Set(key, entry, options);

    public virtual void Remove(string key)
        => _memoryCache.Remove(key);
}