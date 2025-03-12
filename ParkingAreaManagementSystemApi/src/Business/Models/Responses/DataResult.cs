namespace Business.Models.Responses;

public class DataResult<T>(ResultStatus status, string? message = null, T? data = null)
    : Result(status, message) where T : class
{
    public T? Data { get; set; } = data;
}