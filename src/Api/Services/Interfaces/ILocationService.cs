using Api.Model.Loc.Requests;
using Api.Model.Loc.Responses;

namespace Api.Services.Interfaces;

public interface ILocationService
{
    Task<LocationResponse> CriarLocation(CriarLocationRequest req);
}