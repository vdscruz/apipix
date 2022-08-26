global using FastEndpoints;
using Api.Model.Loc.Requests;
using Api.Validation;
using Api.Validation.Loc;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddFastEndpoints()
    .AddScoped<IValidator<CriarLocationRequest>, CriarLocationRequestValidator>();


var app = builder.Build();
app.UseAuthorization();
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints();


app.Run();
