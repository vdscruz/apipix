using Microsoft.Extensions.Caching.Memory;

namespace Application.Interfaces.MemoryCache;

public interface ICacheService<T>
{
    Task<T> GetAsync(string key);
    void Set(string key, T entry, MemoryCacheEntryOptions options = null);
    void Remove(string key);
}