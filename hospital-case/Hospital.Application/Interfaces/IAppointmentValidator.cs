using Hospital.Domain.Entities;

namespace Hospital.Application.Interfaces;

public interface IAppointmentValidator
{
    Task<bool> ValidateAsync(Appointment appointment);
}