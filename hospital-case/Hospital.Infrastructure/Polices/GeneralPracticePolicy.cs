using Hospital.Domain.Entities;
using Hospital.Domain.Policies;

namespace Hospital.Infrastructure.Polices;

public class GeneralPracticePolicy: IDepartmentPolicy
{
    public string DepartmentNaem  => "General Practice";
    public Task<ValidationResult> ValidateAsync(Appointment appointment)
    {
        if (!IsAssignedToGP(appointment.Cpr, appointment.DoctorName))
        {
            var errorMessage = "Patients can only book appointments with their assigned GP.";
            Console.WriteLine($"[ERROR] {errorMessage}");
            return Task.FromResult(ValidationResult.Failure(errorMessage));
        }

        return Task.FromResult(ValidationResult.Success());
    }

    private bool IsAssignedToGP(string cpr, string doctorName)
    {
        Console.WriteLine($"[LOG] Checking GP assignment for {cpr}");
        return true; // Dummy check (To be implemented later)
    }
}