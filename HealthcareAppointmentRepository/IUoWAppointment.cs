using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointmentModels;

namespace HealthcareAppointmentRepository
{
    public interface IUoWAppointment : IDisposable
    {
        Task<int> TakeAppointment(Appointment appointment);

        Task<List<Appointment>> GetAllAppoints();

        Task<List<Appointment>> GetAllAppointsByUser(string userName);

        Task<bool> CancelAppointment(long id, Appointment appointment);
    }
}
