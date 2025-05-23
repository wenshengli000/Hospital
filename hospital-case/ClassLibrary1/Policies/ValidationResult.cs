namespace Hospital.Domain.Policies;

public record ValidationResult(bool IsSuccess, string ErrorMessage = "")
{
    public bool IsSuccess { get; init; }
    public string ErrorMessage { get; init; } = string.Empty;
    public static ValidationResult Success() => new(true);
    public static ValidationResult Failure(string message) => new(false, message);
}