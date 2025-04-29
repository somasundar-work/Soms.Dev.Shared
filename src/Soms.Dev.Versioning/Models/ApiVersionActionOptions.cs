using Microsoft.AspNetCore.Mvc;

namespace Soms.Dev.Versioning;

public class ApiVersionActionOptions
{
    public ApiVersion DefaultVersion { get; set; } = new ApiVersion(1, 0);
    public ApiVersionType Type { get; set; } = ApiVersionType.Header;
}
