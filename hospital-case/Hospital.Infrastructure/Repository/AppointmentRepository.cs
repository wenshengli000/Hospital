using Hospital.Application.Interfaces;
using Hospital.Domain.Entities;
using Hospital.Infrastructure.Persistance;

namespace Hospital.Infrastructure.Repository;
public class AppointmentRepository(AppointmentDbContext dbContext) : IAppointmentRepository
{
    public async Task AddAsync(Appointment appointment)
    {
        dbContext.Appointments.Add(appointment);
        await dbContext.SaveChangesAsync();
    }
}