using Api.Validation.Loc;
using Application.Model.Loc.Requests;
using FluentValidation;

namespace Api.Validation;

public static class ValidationExtension
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddScoped<IValidator<CriarLocationRequest>, CriarLocationRequestValidator>();
        
        return services;
    }
}