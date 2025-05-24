using Hospital.Domain.Entities;
using Hospital.Domain.Policies;

namespace Hospital.Infrastructure.Polices;

public class RadiologyPolicy : IDepartmentPolicy
{
    public string DepartmentName => "Radiology";
    public Task<ValidationResult> ValidateAsync(Appointment appointment)
    {
        if (RequiresReferral(appointment.Department) && !HasValidReferral(appointment.Cpr))
            return Task.FromResult(ValidationResult.Failure("Radiology requires a doctor's referral."));

        if (RequiresFinancialApproval(appointment.Department) && !HasValidFinancialApproval(appointment.Cpr, appointment.Department))
            return Task.FromResult(ValidationResult.Failure("Radiology procedures may require financial approval."));

        return Task.FromResult(ValidationResult.Success());
    }

    private bool HasValidReferral(string cpr) => true; 
    private bool HasValidFinancialApproval(string cpr, string department) => true;
    private bool RequiresReferral(string department)
    {
        return department == "Surgery" || department == "Radiology" || department == "Physiotherapy";
    }

    private bool RequiresFinancialApproval(string department)
    {
        return department == "Radiology";
    }
}
