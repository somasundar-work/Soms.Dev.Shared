using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Soms.Dev.ResponseHandling.Middleware;

public class GlobalExceptionHandling : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandling> _logger;
    private readonly IHostEnvironment _environment;

    public GlobalExceptionHandling(ILogger<GlobalExceptionHandling> logger, IHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)HttpStatusCode.OK;

        var errorResponse = new Result<bool>
        {
            IsSuccess = false,
            Message = "An unexpected error occurred.",
            Data = false,
            Errors = _environment.IsDevelopment() ? new[] { exception.Message } : null,
        };

        return response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
