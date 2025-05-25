using Hospital.Domain.Entities;
using Hospital.Domain.Policies;
using Microsoft.Extensions.Logging;

namespace Hospital.Infrastructure.Polices;

public class PhysiotherapyPolicy(ILogger<GeneralPracticePolicy> logger) : IDepartmentPolicy
{
    public string DepartmentName => "Physiotherapy";
    public Task<ValidationResult> ValidateAsync(Appointment appointment)
    {
        if (RequiresReferral(appointment.Department) && !HasValidReferral(appointment.Cpr))
            return Task.FromResult(ValidationResult.Failure("Physiotherapy requires a doctor's referral."));

        if (RequiresInsuranceApproval(appointment.Department) && !HasValidInsuranceApproval(appointment.Cpr))
            return Task.FromResult(ValidationResult.Failure("Physiotherapy requires valid insurance approval."));

        return Task.FromResult(ValidationResult.Success());
    }

    private bool HasValidReferral(string cpr) => true; 
    private bool HasValidInsuranceApproval(string cpr) => true;
    private bool RequiresInsuranceApproval(string department) => true;
    private bool RequiresReferral(string department) => true;
}
