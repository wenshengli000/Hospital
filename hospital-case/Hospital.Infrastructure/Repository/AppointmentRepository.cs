using Hospital.Application.Interfaces;
using Hospital.Domain.Entities;

namespace Hospital.Infrastructure.Repository
{
    public class AppointmentRepository: IAppointmentRepository
    {
        public Task AddAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
