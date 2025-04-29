using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Soms.Dev.Versioning;

public static class ServiceExtension
{
    public static IServiceCollection AddVersioning(
        this IServiceCollection services,
        Action<ApiVersionActionOptions>? setupAction = null
    )
    {
        ApiVersionActionOptions defaultOptions = new();
        setupAction?.Invoke(defaultOptions);

        IApiVersionReader apiVersionReader = defaultOptions.Type switch
        {
            ApiVersionType.Header => new HeaderApiVersionReader("x-api-version"),
            ApiVersionType.Query => new QueryStringApiVersionReader("api-version"),
            ApiVersionType.Path => new UrlSegmentApiVersionReader(),
            _ => throw new ArgumentOutOfRangeException(nameof(setupAction), "Invalid ApiVersionType"),
        };
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = defaultOptions.DefaultVersion;
            options.ApiVersionReader = apiVersionReader;
        });
        return services;
    }
}
