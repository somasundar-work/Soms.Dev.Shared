namespace Soms.Dev.Versioning;

/// <summary>
/// Specifies the type of API versioning mechanism used in the application.
/// </summary>
public enum ApiVersionType
{
    /// <summary>
    /// API versioning is specified in the request header.
    /// </summary>
    Header,

    /// <summary>
    /// API versioning is specified as a query parameter in the URL.
    /// </summary>
    Query,

    /// <summary>
    /// API versioning is specified as part of the URL path.
    /// </summary>
    Path,
}
