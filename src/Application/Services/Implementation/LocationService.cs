using Application.Model.Loc.Requests;
using Application.Model.Loc.Responses;
using Application.Services.Interfaces;

namespace Application.Services.Implementation;

public class LocationService: ILocationService
{
    public Task<LocationResponse> CriarLocation(CriarLocationRequest req)
    {
        
        throw new NotImplementedException();
    }
}