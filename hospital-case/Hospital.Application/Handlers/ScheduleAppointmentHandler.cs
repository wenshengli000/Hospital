using Hospital.Application.Commands;
using Hospital.Application.Interfaces;
using Hospital.Domain.Entities;
using Hospital.Domain.Policies;
using MediatR;

namespace Hospital.Application.Handlers;

public class ScheduleAppointmentHandler(
    IAppointmentRepository repository,
    IEnumerable<IDepartmentPolicy> policies,
    IAppointmentValidator appointmentValidator, 
    ICprValidator cprValidator)
    : IRequestHandler<ScheduleAppointmentCommand, ScheduleResult>
{
    public async Task<ScheduleResult> Handle(ScheduleAppointmentCommand cmd, CancellationToken ct)
    {
        var validationResult = await cprValidator.ValidateAsync(cmd.Cpr);
        if (!validationResult.IsSuccess)
        {
            return ScheduleResult.Failure(validationResult.ErrorMessage);
        }

        var appointment = Appointment.Create(cmd.Cpr, cmd.PatientName, cmd.Date, cmd.Department, cmd.Doctor);
        validationResult = await appointmentValidator.ValidateAsync(appointment);
        if (!validationResult.IsSuccess)
        {
            return ScheduleResult.Failure(validationResult.ErrorMessage);
        }

        var policy = policies.FirstOrDefault(p =>
            p.DepartmentName.Equals(appointment.Department, StringComparison.OrdinalIgnoreCase));

        if (policy == null)
        {
            return ScheduleResult.Failure($"Unsupported department: {appointment.Department}");
        }

        validationResult = await policy.ValidateAsync(appointment);
        if (!validationResult.IsSuccess)
        {
            return ScheduleResult.Failure(validationResult.ErrorMessage);
        }

        await repository.AddAsync(appointment);
        return ScheduleResult.Success("Appointment scheduled successfully.");
    }
}