using Api.Model.Loc.Requests;
using Api.Model.Loc.Responses;
using Api.Validation.Loc;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Api.Endpoints.Loc;

[HttpPost("loc"), Tags("PayloadLocation"), AllowAnonymous]
public class CriarLocationEndpoint: Endpoint<CriarLocationRequest, CriarLocationResponse>
{
    private readonly IValidator<CriarLocationRequest> _validator;

    public CriarLocationEndpoint(IValidator<CriarLocationRequest> validator)
    {
        _validator = validator;
    }


    public override Task HandleAsync(CriarLocationRequest req, CancellationToken ct)
    {
        _validator.ValidateAndThrow(req);
        return Task.CompletedTask;
    }
}