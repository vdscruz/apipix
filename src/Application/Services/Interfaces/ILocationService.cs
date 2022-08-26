using Application.Model.Loc.Requests;
using Application.Model.Loc.Responses;

namespace Application.Services.Interfaces;

public interface ILocationService
{
    Task<LocationResponse> CriarLocation(CriarLocationRequest req);
}