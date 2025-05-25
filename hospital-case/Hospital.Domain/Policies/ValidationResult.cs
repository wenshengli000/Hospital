namespace Hospital.Domain.Policies;

public record ValidationResult(bool IsSuccess, string ErrorMessage = "")
{
    public static ValidationResult Success() => new(true);
    public static ValidationResult Failure(string message) => new(false, message);
}