using Hospital.Application.Interfaces;
using Hospital.Domain.Entities;
using Hospital.Domain.Policies;
using Microsoft.Extensions.Logging;

namespace Hospital.Infrastructure.Services;

public class AppointmentValidator(ILogger<AppointmentValidator> logger) : IAppointmentValidator
{
    public Task<ValidationResult> ValidateAsync(Appointment appointment)
    {
        if (string.IsNullOrWhiteSpace(appointment.Cpr))
            return Task.FromResult(ValidationResult.Failure("CPR is required."));

        if (string.IsNullOrWhiteSpace(appointment.Department))
            return Task.FromResult(ValidationResult.Failure("Department is required."));

        if (string.IsNullOrWhiteSpace(appointment.DoctorName))
            return Task.FromResult(ValidationResult.Failure("Doctor name is required."));

        if (appointment.AppointmentDate < DateTime.Now)
        {
            var message = $"Appointment date must be in the future. AppointmentDate:{appointment.AppointmentDate}";
            logger.LogError(message);
            return Task.FromResult(ValidationResult.Failure(message));
        }

        return Task.FromResult(ValidationResult.Success());
    }
}
