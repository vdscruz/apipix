using Api.Model.Loc.Mapper;
using Api.Model.Loc.Responses;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Loc;

public class GetLocationByIdEndpoint : EndpointWithoutRequest<LocationResponse>
{
    private readonly ILocationService _locationService;

    public override void Configure()
    {
        Get("loc/{id}");
        Tags("PayloadLocation");
        AllowAnonymous();
    }

    public GetLocationByIdEndpoint(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        var location = await _locationService.GetLocationById(id);
        
        if (location is null) await SendNotFoundAsync(cancellation: ct);
        else await SendOkAsync(location!.Map(), cancellation:ct);
            
        
    }
}