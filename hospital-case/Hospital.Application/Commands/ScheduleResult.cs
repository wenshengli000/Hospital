public record ScheduleResult
{
    public bool IsSuccess { get; init; }
    public string ErrorMessage { get; init; } = string.Empty;
    public static ScheduleResult Success(string appointmentScheduledSuccessfully) => new() { IsSuccess = true };
    public static ScheduleResult Failure(string errorMessage) => new() { IsSuccess = false, ErrorMessage = errorMessage };
}