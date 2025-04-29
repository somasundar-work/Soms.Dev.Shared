using System;
using System.Text.Json.Serialization;

namespace Soms.Dev.ResponseHandling;

public class Result<T>
{
    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("errors")]
    public string[]? Errors { get; set; }

    public static Result<T> Success(T data, string? message = null)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message,
        };
    }

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
