namespace Hospital.Application.Commands;

public record ScheduleResult
{
    public bool IsSuccess { get; init; }
    public string Message { get; init; } = string.Empty;
    public static ScheduleResult Success(string successMessage) => new() { IsSuccess = true, Message = successMessage };
    public static ScheduleResult Failure(string errorMessage) => new() { IsSuccess = false, Message = errorMessage };
}