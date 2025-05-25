using Hospital.Domain.Entities;
using Hospital.Domain.Policies;

namespace Hospital.Application.Interfaces;

public interface IAppointmentValidator
{
    Task<ValidationResult> ValidateAsync(Appointment appointment);
}
