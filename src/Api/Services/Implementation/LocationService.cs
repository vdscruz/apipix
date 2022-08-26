using Api.Model.Loc.Requests;
using Api.Model.Loc.Responses;
using Api.Services.Interfaces;

namespace Api.Services.Implementation;

public class LocationService: ILocationService
{
    public Task<LocationResponse> CriarLocation(CriarLocationRequest req)
    {
        throw new NotImplementedException();
    }
}