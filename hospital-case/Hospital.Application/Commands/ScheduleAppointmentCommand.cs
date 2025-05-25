using MediatR;

namespace Hospital.Application.Commands;

public record ScheduleAppointmentCommand(string Cpr, string PatientName, DateTime Date, string Department, string Doctor) : IRequest<ScheduleResult>;
