using Hospital.Application.Interfaces;
using Hospital.Domain.Entities;

namespace Hospital.Application;


public class AppointmentRepository(AppointmentDbContext dbContext) : IAppointmentRepository
{
    public async Task AddAsync(Appointment appointment)
    {
        dbContext.Appointments.Add(appointment);
        await dbContext.SaveChangesAsync();
    }
}