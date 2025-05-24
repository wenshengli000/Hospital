using Hospital.Domain.Entities;

namespace Hospital.Domain.Policies;

public interface IDepartmentPolicy
{
    string DepartmentName { get; }
    Task<ValidationResult> ValidateAsync(Appointment appointment);
}
