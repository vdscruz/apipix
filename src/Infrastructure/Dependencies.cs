using Application.Implementations.Services;
using Application.Interfaces.MemoryCache;
using Application.Interfaces.Services;
using Infrastructure.Implementations.MemoryCache;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        #region # Memory Cache
        services.AddMemoryCache();
        services.AddScoped(typeof(IMemoryCacheService<>), typeof(MemoryCacheService<>));
        #endregion

        services.AddScoped<ILocationService, LocationService>();
        
        return services;
    }
}