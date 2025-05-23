using Hospital.Application.Commands;
using MediatR;

namespace Hospital.Application.Handlers;

public class ScheduleAppointmentHandler: IRequestHandler<ScheduleAppointmentCommand, ScheduleResult>
{
    public Task<ScheduleResult> Handle(ScheduleAppointmentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}