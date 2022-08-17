using api.Enum;
using Api.Model.Loc.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Api.Validation.Loc;

public class CriarLocationRequestValidator: AbstractValidator<CriarLocationRequest>
{
    private string tipCobErroMessage = "o campo \"tipoCob\" não respeita o schema.";
    public CriarLocationRequestValidator()
    {
        RuleFor(x => x.TipoCob)
            .NotEmpty().WithMessage(tipCobErroMessage)
            .WithErrorCode(Enum.GetName(TratamentoErrosEnum.PayloadLocationOperacaoInvalida)) // Não pode ser vazio
            .IsEnumName(typeof(TipoCob)).WithMessage(tipCobErroMessage)
            .WithErrorCode(Enum.GetName(TratamentoErrosEnum.PayloadLocationOperacaoInvalida)); // tem que ser igual a um dos itens do enum 
    }
}