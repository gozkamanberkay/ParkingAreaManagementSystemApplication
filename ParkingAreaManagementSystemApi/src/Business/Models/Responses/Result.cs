namespace Business.Models.Responses;

public class Result(ResultStatus status, string? message = null)
{
    public ResultStatus Status { get; set; } = status;
    public string? Message { get; set; } = message;
}

public enum ResultStatus
{
    Ok = 10,
    Error = 20
}