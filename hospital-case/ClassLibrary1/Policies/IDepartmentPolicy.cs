using Hospital.Domain.Entities;

namespace Hospital.Domain.Policies;

public interface IDepartmentPolicy
{
    string DepartmentNaem { get; }
    Task<ValidationResult> ValidateAsync(Appointment appointment);
}
