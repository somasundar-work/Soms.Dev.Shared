using System;
using System.Text.Json.Serialization;

namespace Soms.Dev.ResponseHandling;

/// <summary>
/// Represents a paginated result that extends the base <see cref="Result{T}"/> class.
/// </summary>
/// <typeparam name="T">The type of the data contained in the result.</typeparam>
public class PaginatedResult<T> : Result<T>
{
    /// <summary>
    /// Gets or sets the current page number of the paginated result. Default is 1.
    /// </summary>
    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Gets or sets the number of items per page in the paginated result. Default is 10.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// Gets or sets the total number of items across all pages.
    /// </summary>
    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; } = 0;

    /// <summary>
    /// Gets the total number of pages based on <see cref="TotalCount"/> and <see cref="PageSize"/>.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    /// <summary>
    /// Creates a successful paginated result with the specified data, pagination details, and an optional message.
    /// </summary>
    /// <param name="data">The data to include in the result.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="totalCount">The total number of items across all pages.</param>
    /// <param name="message">An optional message to include in the result.</param>
    /// <returns>A <see cref="PaginatedResult{T}"/> representing a successful result.</returns>
    public static PaginatedResult<T> Success(
        T data,
        int pageNumber,
        int pageSize,
        int totalCount,
        string? message = null
    )
    {
        return new PaginatedResult<T>
        {
            IsSuccess = true,
            Data = data,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            Message = message,
        };
    }
}
