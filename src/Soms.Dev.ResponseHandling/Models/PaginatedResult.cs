using System;

namespace Soms.Dev.ResponseHandling;

public class PaginatedResult<T> : Result<T>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; } = 0;
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

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
