using System.Collections;
using Application.Dto;
using Application.Interfaces.MemoryCache;
using Application.Interfaces.Services;

namespace Application.Implementations.Services;

public class LocationService: ILocationService
{
    private readonly ICacheService<IEnumerable<LocationDTO>> _cacheService;

    public LocationService(ICacheService<IEnumerable<LocationDTO>> cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<LocationDTO> CreateLocation(int tipoCob)
    {
        var locations = await FindLocations();
        var locationDtos = locations.ToList();
        
        var location = new LocationDTO(locationDtos.Count() + 1, tipoCob);
        locationDtos.Add(location);
        _cacheService.Set("locations", locationDtos);
        
        return location;
    }

    public async Task<IEnumerable<LocationDTO>> FindLocations()
    {
        return await _cacheService.GetAsync("locations") ?? Enumerable.Empty<LocationDTO>();
    }

    public async Task<LocationDTO?> GetLocationById(long id)
    {
        var locations = await FindLocations();
        return locations.FirstOrDefault(p => p.Id == id);
    }

    public void RemoveLocation(long id)
    {
        throw new NotImplementedException();
    }
}