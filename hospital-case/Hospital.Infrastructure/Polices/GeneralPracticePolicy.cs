using Hospital.Domain.Entities;
using Hospital.Domain.Policies;

namespace Hospital.Infrastructure.Polices;

public class GeneralPracticePolicy: IDepartmentPolicy
{
    public string DepartmentNaem { get; }
    public Task<ValidationResult> ValidateAsync(Appointment appointment)
    {
        throw new NotImplementedException();
    }
}