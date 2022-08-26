using Application.Enum;
using Application.Model.Loc.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Api.Validation.Loc;

public class CriarLocationRequestValidator: AbstractValidator<CriarLocationRequest>
{
    private string tipCobErroMessage = "o campo \"tipoCob\" não respeita o schema.";
    public CriarLocationRequestValidator()
    {
        // Não pode ser vazio
        RuleFor(x => x.TipoCob)
            .NotEmpty().WithMessage(tipCobErroMessage)
            .WithErrorCode(Enum.GetName(TratamentoErrosEnum.PayloadLocationOperacaoInvalida));
            
        // Tem que ser igual a um dos itens do enum 
        RuleFor(x => x.TipoCob)   
            .IsEnumName(typeof(TipoCob)).WithMessage(tipCobErroMessage)
            .WithErrorCode(Enum.GetName(TratamentoErrosEnum.PayloadLocationOperacaoInvalida)); 
    }
}