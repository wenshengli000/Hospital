using Hospital.Domain.Entities;
using Hospital.Domain.Policies;
using Microsoft.Extensions.Logging;

namespace Hospital.Infrastructure.Polices;

public class SurgeryPolicy(ILogger<GeneralPracticePolicy> logger) : IDepartmentPolicy
{
    public string DepartmentName => "Surgery";
    public Task<ValidationResult> ValidateAsync(Appointment appointment)
    {
        if (RequiresReferral(appointment.Department) && !HasValidReferral(appointment.Cpr, appointment.Department))
            return Task.FromResult(ValidationResult.Failure("Surgery requires a specialist referral."));
        return Task.FromResult(ValidationResult.Success());
    }

    private bool HasValidReferral(string cpr, string department) => true;
    private bool RequiresReferral(string department) => true;
}