using Microsoft.AspNetCore.Mvc;

namespace Soms.Dev.Versioning;

/// <summary>
/// Represents the configuration options for API versioning actions.
/// </summary>
public class ApiVersionActionOptions
{
    /// <summary>
    /// Gets or sets the default API version to be used when no version is specified.
    /// </summary>
    public ApiVersion DefaultVersion { get; set; } = new ApiVersion(1, 0);

    /// <summary>
    /// Gets or sets the type of API versioning to be used (e.g., via headers or query parameters).
    /// </summary>
    public ApiVersionType Type { get; set; } = ApiVersionType.Header;
}
