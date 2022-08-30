using System.Text.Json;
using Api.Enum;
using ErrorResponse = Api.Model.ErrorResponse;

namespace Api.Middlewares;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorMiddleware> _logger;

    public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = 500;
            
            ErrorResponse errorResponse = new ErrorResponse(TratamentoErrosEnum.ErroInternoDoServidor);
            var result = JsonSerializer.Serialize(errorResponse);
            await response.WriteAsync(result);
        }
    }
}