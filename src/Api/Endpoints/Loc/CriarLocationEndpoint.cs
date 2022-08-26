using Application.Enum;
using Application.Model.Loc.Requests;
using Application.Model.Loc.Responses;
using FluentValidation;

namespace Api.Endpoints.Loc;

public class CriarLocationEndpoint: Endpoint<CriarLocationRequest, LocationResponse>
{
    private readonly IValidator<CriarLocationRequest> _validator;

    public CriarLocationEndpoint(IValidator<CriarLocationRequest> validator)
    {
        _validator = validator;
    }

    public override void Configure()
    {
        Post("loc");
        Tags("PayloadLocation");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CriarLocationRequest req, CancellationToken ct)
    {
        await _validator.ValidateAndThrowAsync(req, ct);

        var response = new LocationResponse()
        {
            Id = 7716,
            Location = "pix.example.com/qr/v2/2353c790eefb11eaadc10242ac120002",
            TipoCob = Enum.Parse<TipoCob>(req.TipoCob),
            Criacao = DateTime.Now,
        };
        
        await SendCreatedAtAsync<ConsultarLocationPorIdEndpoint>(null, response, cancellation: ct);
    }
}