using Hospital.Application.Interfaces;
using Hospital.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Hospital.Infrastructure.Services;

public class AppointmentValidator(ILogger<AppointmentValidator> logger) : IAppointmentValidator
{
    public Task<bool> ValidateAsync(Appointment appointment)
    {
        if (string.IsNullOrWhiteSpace(appointment.Cpr) ||
            string.IsNullOrWhiteSpace(appointment.Department) ||
            string.IsNullOrWhiteSpace(appointment.DoctorName) ||
            appointment.AppointmentDate < DateTime.Now)
        {
            logger.LogError("Invalid appointment request: {@Appointment}", appointment);
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
}