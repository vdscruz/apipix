using Application.Dto;

namespace Application.Interfaces.Services;

public interface ILocationService
{
    Task<LocationDTO> CreateLocation(int tipoCob);
    Task<IEnumerable<LocationDTO>> FindLocations();
    Task<LocationDTO?> GetLocationById(long id);
    void RemoveLocation(long Id);
}