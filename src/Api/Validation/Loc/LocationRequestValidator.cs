using Api.Model.Loc.Requests;
using Application.Enum;

namespace Api.Validation.Loc;

public class LocationRequestValidator<T>: Validator<T> where T: LocationRequest
{
    private string tipCobErroMessage = "o campo \"tipoCob\" não respeita o schema.";
    
    protected void TipoCobNotEmpty()
    {
        RuleFor(x => x.TipoCob)
            .NotEmpty().WithMessage(tipCobErroMessage)
            .WithErrorCode(System.Enum.GetName(TratamentoErrosEnum.PayloadLocationOperacaoInvalida));
    }

    protected void TipoCobValidFromEnum()
    {
        RuleFor(x => x.TipoCob)   
            .IsEnumName(typeof(TipoCob)).WithMessage(tipCobErroMessage)
            .WithErrorCode(System.Enum.GetName(TratamentoErrosEnum.PayloadLocationOperacaoInvalida)); 
    }
}