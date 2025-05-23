using Hospital.Application.Interfaces;
using Hospital.Domain.Policies;
using Hospital.Infrastructure.Persistance;
using Hospital.Infrastructure.Polices;
using Hospital.Infrastructure.Repository;
using Hospital.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppointmentDbContext>(options =>
    options.UseInMemoryDatabase("HospitalDb"));
builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<AppointmentService>(); 
builder.Services.AddScoped<IDepartmentPolicy, GeneralPracticePolicy>();
builder.Services.AddSingleton<ICprValidator, NationalRegistryCprValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/appointments", async (AppointmentRequest request, AppointmentService appointmentService) =>
{
    var result = await appointmentService.ScheduleAppointment(
        request.Cpr, request.PatientName, request.AppointmentDate,
        request.Department, request.DoctorName);

    if (result)
        return Results.Ok("Appointment scheduled successfully.");
    else
        return Results.BadRequest("Failed to schedule the appointment.");
});

app.Run();

// Updated AppointmentRequest model
public record AppointmentRequest(string Cpr, string PatientName, DateTime AppointmentDate, string Department, string DoctorName);