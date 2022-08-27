global using FastEndpoints;
using Api.Validation;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddFastEndpoints()
    .AddValidators();


var app = builder.Build();
app.UseAuthorization();
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints();


app.Run();
