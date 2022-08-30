using Api.Model.Loc.Requests;
using Api.Model.Loc.Responses;
using Api.Enum;
using Api.Model.Loc.Mapper;
using Application.Interfaces.Services;

namespace Api.Endpoints.Loc;

public class CreateLocationEndpoint: Endpoint<CriarLocationRequest, LocationResponse>
{
    private readonly ILocationService _locationService;

    public override void Configure()
    {
        Post("loc");
        Tags("PayloadLocation");
        AllowAnonymous();
    }

    public CreateLocationEndpoint(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public override async Task HandleAsync(CriarLocationRequest req, CancellationToken ct)
    {
        var locationsCreated = await _locationService.CreateLocation((int) System.Enum.Parse<TipoCob>(req.TipoCob));
        await SendCreatedAtAsync<GetLocationByIdEndpoint>("teste", locationsCreated.Map(), cancellation: ct);
    }
}