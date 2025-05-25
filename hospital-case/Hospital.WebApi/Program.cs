using Hospital.Application.Commands;
using Hospital.Application.Handlers;
using Hospital.Application.Interfaces;
using Hospital.Domain.Policies;
using Hospital.Infrastructure.Persistance;
using Hospital.Infrastructure.Polices;
using Hospital.Infrastructure.Repository;
using Hospital.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppointmentDbContext>(options =>
    options.UseInMemoryDatabase("HospitalDb"));
builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<IDepartmentPolicy, GeneralPracticePolicy>();
builder.Services.AddScoped<IDepartmentPolicy, PhysiotherapyPolicy>();
builder.Services.AddScoped<IDepartmentPolicy, RadiologyPolicy>();
builder.Services.AddScoped<IDepartmentPolicy, SurgeryPolicy>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentValidator, AppointmentValidator>();
builder.Services.AddSingleton<ICprValidator, NationalRegistryCprValidator>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<ScheduleAppointmentHandler>();
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/appointments", async (AppointmentRequest request, IMediator mediator) =>
{
    var command = new ScheduleAppointmentCommand(
        request.Cpr,
        request.PatientName,
        request.AppointmentDate,
        request.Department,
        request.DoctorName
    );

    var result = await mediator.Send(command);

    if (!result.IsSuccess)
        return Results.BadRequest(result.Message);

    return Results.Ok(result.Message);
});


app.Run();

// Updated AppointmentRequest model
public record AppointmentRequest(string Cpr, string PatientName, DateTime AppointmentDate, string Department, string DoctorName);