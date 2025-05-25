    namespace Hospital.Domain.Entities;

public class Appointment(
    string cpr,
    string patientName,
    DateTime appointmentDate,
    string department,
    string doctorName)
{
    public int Id { get; set; }

    public string Cpr { get; private set; } = cpr;

    public string PatientName { get; private set; } = patientName;

    public DateTime AppointmentDate { get; private set; } = appointmentDate;

    public string Department { get; private set; } = department;

    public string DoctorName { get; private set; } = doctorName;

    public static Appointment Create(string cpr, string patientName, DateTime appointmentDate, string department, string doctorName)
    {
        return new Appointment(cpr, patientName, appointmentDate, department, doctorName);
    }
}