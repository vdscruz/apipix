using Api.Validation.Loc;
using FluentValidation;

namespace Api.Validation;

public static class ValidationExtension
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        //services.AddScoped<IValidator<CriarLocationRequest>, CriarLocationRequestValidator>();
        
        return services;
    }
}