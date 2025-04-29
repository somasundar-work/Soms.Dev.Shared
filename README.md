# Soms.Dev.Shared

A shared library for .NET projects that provides common utilities, middleware, and extensions. This library is designed to simplify development by offering reusable components that address common application needs, such as error handling and API versioning.

## Features

- **Global Exception Handling**: Middleware for centralized error handling.
- **API Versioning**: Simplified setup for API versioning.

## Installation

1. Add the library to your project:
   ```bash
   dotnet add package Soms.Dev.Shared
   ```

## Usage

### Global Exception Handling Middleware

To enable global exception handling in your application, add the middleware in the `Startup.cs` or `Program.cs` file:

```csharp
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
```

This middleware will catch unhandled exceptions and return a standardized error response.

### API Versioning

To set up API versioning, configure it in the `Startup.cs` or `Program.cs` file:

```csharp
services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
```

This configuration ensures that your APIs support versioning and provides a default version when none is specified.

## Examples

### Example: Global Exception Handling

```csharp
public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected error occurred.");
        }
    }
}
```

### Example: API Versioning

```csharp
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class SampleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("This is version 1.0 of the API.");
    }
}
```

With these examples, you can quickly integrate the library into your .NET projects and take advantage of its features.
