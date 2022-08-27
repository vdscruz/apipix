using Api.Model.Loc.Requests;

namespace Api.Validation.Loc;

public class CriarLocationRequestValidator: LocationRequestValidator<CriarLocationRequest>
{
    public CriarLocationRequestValidator()
    {
        TipoCobNotEmpty();
        TipoCobValidFromEnum();
    }
}