using Hospital.Domain.Policies;

namespace Hospital.Application.Interfaces;

public interface ICprValidator
{
    Task<ValidationResult> ValidateAsync(string cpr);
}
