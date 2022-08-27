global using FastEndpoints;
global using FluentValidation;
using Api.Validation;
using Api.Enum;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddFastEndpoints();
    //.AddValidators();


var app = builder.Build();
app.UseAuthorization();
//app.UseFastEndpoints();
app.UseFastEndpoints(config =>
{
    config.ErrorResponseBuilder = (failures, i) =>
    {
        var validationFailures = failures.ToList();
        var validacoes = validationFailures.Select(x => new Validacoes(x.PropertyName, x.ErrorMessage));
        var erro = Enum.Parse<TratamentoErrosEnum>(validationFailures.FirstOrDefault()!.ErrorCode);
        var validationFailureResponse = new ValidationFailureResponse(erro)
        {
            Codigo = 400,
            Validacoes = validacoes
        };

        return validationFailureResponse;
    };
});


app.Run();
