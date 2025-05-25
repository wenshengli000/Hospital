using Hospital.Domain.Entities;
using Hospital.Domain.Policies;
using Microsoft.Extensions.Logging;

namespace Hospital.Infrastructure.Polices;

public class GeneralPracticePolicy(ILogger<GeneralPracticePolicy> logger) : IDepartmentPolicy
{
    public string DepartmentName => "General Practice";

    public Task<ValidationResult> ValidateAsync(Appointment appointment)
    {
        if (!IsAssignedToGp(appointment.Cpr, appointment.DoctorName))
        {
            const string errorMessage = "Patients can only book appointments with their assigned GP.";
            logger.LogError("Validation failed for {Cpr}: {Error}", appointment.Cpr, errorMessage);
            return Task.FromResult(ValidationResult.Failure(errorMessage));
        }

        logger.LogInformation("Validation passed: Assigned GP confirmed for {Cpr}", appointment.Cpr);
        return Task.FromResult(ValidationResult.Success());
    }

    private bool IsAssignedToGp(string cpr, string doctorName)
    {
        logger.LogDebug("Checking GP assignment for {Cpr} with doctor {Doctor}", cpr, doctorName);
        return true; // Dummy logic — replace with real service call
    }
}