using Hospital.Application.Interfaces;
using Hospital.Domain.Entities;

namespace Hospital.Infrastructure.Services;

public class ApointmentValidator: IAppointmentValidator
{
    public Task<bool> ValidateAsync(Appointment appointment)
    {
        // Basic validation
        if (string.IsNullOrEmpty(appointment.Cpr) || string.IsNullOrEmpty(appointment.Department) ||
            string.IsNullOrEmpty(appointment.DoctorName) || appointment.AppointmentDate < DateTime.Now)
        {
            Console.WriteLine("Invalid appointment request.");
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
}