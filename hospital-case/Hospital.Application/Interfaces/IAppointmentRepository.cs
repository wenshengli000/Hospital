using Hospital.Domain.Entities;

namespace Hospital.Application.Interfaces;

public interface IAppointmentRepository
{
    Task AddAsync(Appointment appointment);
}