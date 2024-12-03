using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointmentModels;

namespace HealthcareAppointmentRepository
{
    public interface IUoWUser : IDisposable
    {
        Task<List<User>> GetUsers();

        Task<List<UsersWithAppointment>> GetUsersWithAppointment();
        Task GetUsersAsync();
        Task Save();

        Task Register(Register registerModel);
    }
}
