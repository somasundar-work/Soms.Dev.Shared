# Soms.Dev.Shared

A shared library for .NET projects that provides common utilities, middleware, and extensions. This library is designed to simplify development by offering reusable components that address common application needs, such as error handling and API versioning.

## Features

- **Global Exception Handling**: Middleware for centralized error handling.
- **API Versioning**: Simplified setup for API versioning.

## Installation

Each feature is available as a separate NuGet package. Install the package(s) you need:

### Soms.Dev.ResponseHandling

For global exception handling, install the `Soms.Dev.ResponseHandling` package:

```bash
dotnet add package Soms.Dev.ResponseHandling
```

### Soms.Dev.Versioning

For API versioning, install the `Soms.Dev.Versioning` package:

```bash
dotnet add package Soms.Dev.Versioning
```

## Usage

### Global Exception Handling Middleware (Soms.Dev.ResponseHandling)

To enable global exception handling in your application:

1. Add the `Soms.Dev.ResponseHandling` NuGet package to your project.
2. Use the `UseGlobalExceptionHandling` extension method in your application's middleware pipeline (e.g., in `Program.cs`).

#### Example Usage:

```csharp
app.UseGlobalExceptionHandling();
```

This middleware will intercept unhandled exceptions and return a standardized error response.

---

### API Versioning (Soms.Dev.Versioning)

To set up API versioning in your application:

1. Add the `Soms.Dev.Versioning` NuGet package to your project.
2. Use the `AddVersioning` extension method to configure API versioning in your service collection (e.g., in `Program.cs`).

#### Example Usage:

```csharp
builder.Services.AddVersioning(options =>
{
    options.DefaultVersion = new ApiVersion(1, 0);
    options.Type = ApiVersionType.Header; // Options: Header, Query, Path
});
```

This configuration ensures that your APIs support versioning and provides a default version when none is specified.

---

## Summary of Extensions

### `UseGlobalExceptionHandling` (Soms.Dev.ResponseHandling)

- **Purpose**: Adds middleware for centralized exception handling.
- **How to Use**: Call `app.UseGlobalExceptionHandling()` in your middleware pipeline.

### `AddVersioning` (Soms.Dev.Versioning)

- **Purpose**: Configures API versioning for your application.
- **How to Use**: Call `builder.Services.AddVersioning()` and provide configuration options such as the default API version and versioning type (Header, Query, or Path).

---

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests to improve the library.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
