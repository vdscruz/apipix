global using FastEndpoints;
global using FluentValidation;

using Api.Validation;
using Api.Enum;
using Api.Middlewares;
using Infrastructure;
using Infrastructure.Util;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddFastEndpoints()
    .AddDependencies();


var app = builder.Build();
app.UseAuthorization();
app.UseMiddleware<ErrorMiddleware>();
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

    config.SerializerOptions = options =>
    {
        options.Converters.Add(new CustomDateTimeConverter());
        options.Converters.Add(new CustomDatetimNullConverter());
    };
    
});


app.Run();
