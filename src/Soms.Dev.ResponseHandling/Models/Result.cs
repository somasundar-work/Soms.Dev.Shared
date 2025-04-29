using System;
using System.Text.Json.Serialization;

namespace Soms.Dev.ResponseHandling;

/// <summary>
/// Represents the result of an operation, encapsulating success status, data, message, and errors.
/// </summary>
/// <typeparam name="T">The type of the data returned in the result.</typeparam>
public class Result<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation was successful.
    /// </summary>
    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Gets or sets an optional message providing additional information about the result.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the data returned by the operation, if successful.
    /// </summary>
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    /// <summary>
    /// Gets or sets an array of error messages, if the operation failed.
    /// </summary>
    [JsonPropertyName("errors")]
    public string[]? Errors { get; set; }

    /// <summary>
    /// Creates a successful result with the specified data and an optional message.
    /// </summary>
    /// <param name="data">The data to include in the result.</param>
    /// <param name="message">An optional message providing additional information.</param>
    /// <returns>A <see cref="Result{T}"/> representing a successful operation.</returns>
    public static Result<T> Success(T data, string? message = null)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message,
        };
    }

    /// <summary>
    /// Creates a failed result with the specified message and optional errors.
    /// </summary>
    /// <param name="message">A message describing the failure.</param>
    /// <param name="errors">An optional array of error messages providing additional details.</param>
    /// <returns>A <see cref="Result{T}"/> representing a failed operation.</returns>
    public static Result<T> Failure(string message, string[]? errors = null)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Errors = errors,
            Message = message,
        };
    }
}
