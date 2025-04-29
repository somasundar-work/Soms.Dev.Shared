using System;
using Microsoft.AspNetCore.Builder;
using Soms.Dev.ResponseHandling.Middleware;

namespace Soms.Dev.ResponseHandling.Extensions;

/// <summary>
/// Provides extension methods for configuring application-level middleware.
/// </summary>
public static class AppExtensions
{
    /// <summary>
    /// Adds global exception handling middleware to the application's request pipeline.
    /// This middleware intercepts unhandled exceptions and processes them in a centralized manner.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance to configure.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance with the middleware configured.</returns>
    public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandling>();
        return app;
    }
}
