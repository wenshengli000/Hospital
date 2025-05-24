using Hospital.Domain.Entities;
using Hospital.Domain.Policies;
using Hospital.Infrastructure.Repository;

namespace Hospital.Infrastructure.Services;

public class AppointmentService(AppointmentRepository appointmentRepository, IEnumerable<IDepartmentPolicy> departmentPolicies)
{
    public async Task<bool> ScheduleAppointment(
        string cpr, string patientName, DateTime appointmentDate,
        string department, string doctorName)
    {

        // Basic validation
        if (string.IsNullOrEmpty(cpr) || string.IsNullOrEmpty(department) ||
            string.IsNullOrEmpty(doctorName) || appointmentDate < DateTime.Now)
        {
            Console.WriteLine("[ERROR] Invalid appointment request.");
            return false;
        }

        // Validate CPR before scheduling
        if (!await new NationalRegistryService().ValidateCpr(cpr))
        {
            Console.WriteLine("[ERROR] Invalid CPR number. Cannot schedule appointment.");
            return false;
        }

        Console.WriteLine($"[LOG] Scheduling appointment for {patientName} (CPR: {cpr}) in {department} with {doctorName} on {appointmentDate}");

        var policy = departmentPolicies.FirstOrDefault(p =>
            p.DepartmentName.Equals(department, StringComparison.OrdinalIgnoreCase));

        if (policy == null)
        {
            Console.WriteLine($"[ERROR] Unsupported department: {department}");
            return false;
        }

        var appointment = Appointment.Create(cpr, patientName, appointmentDate, department, doctorName);
        var validation = await policy.ValidateAsync(appointment);

        if (!validation.IsSuccess)
        {
            Console.WriteLine($"[ERROR] {validation.ErrorMessage}");
            return false;
        }

        await appointmentRepository.AddAsync(appointment);
        Console.WriteLine($"[LOG] Appointment successfully scheduled for {patientName} (CPR: {cpr})");

        return true;
    }
}