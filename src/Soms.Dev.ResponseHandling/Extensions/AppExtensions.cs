using System;
using Microsoft.AspNetCore.Builder;
using Soms.Dev.ResponseHandling.Middleware;

namespace Soms.Dev.ResponseHandling.Extensions;

public static class AppExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandling>();
        return app;
    }
}
