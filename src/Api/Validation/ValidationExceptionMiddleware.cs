using Application.Enum;
using FluentValidation;

namespace Api.Validation;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _request;

    public ValidationExceptionMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (ValidationException exception)
        {
            context.Response.StatusCode = 400;
            var validacoes = exception.Errors.Select(x => new Validacoes(x.PropertyName, x.ErrorMessage));
            var erro = Enum.Parse<TratamentoErrosEnum>(exception.Errors.FirstOrDefault()!.ErrorCode);
            var validationFailureResponse = new ValidationFailureResponse(erro)
            {
                Codigo = 400,
                Validacoes = validacoes
            };
            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
    }
}