using HealthcareAppointmentModels;

namespace HealthcareAppointmentServices
{
    public interface IAppointmentInterface
    {
        Task<int> BookAppointment(AppointmentModel appointment);

        Task<List<Appointment>> GetAllAppointments();

        Task<List<Appointment>> GetAllAppointsByUser(string userName);

        Task<bool> CancelAppointment(long id, Appointment appointment);
    }
}
