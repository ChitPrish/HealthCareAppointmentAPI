using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointmentModels;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentRepository
{
    public class UserRepository : IUoWUser
    {
        public HealthcareAppointmentModels.HealthcareAppointmentContext _healthcareAppointmentContext;
        public UserRepository(HealthcareAppointmentContext healthcareAppointmentContext) 
        {
            _healthcareAppointmentContext = healthcareAppointmentContext;
        }

        private IGenericRepository<User> _userRepository;

        public IGenericRepository<User> User => _userRepository ?? new GenericRepository<User>(_healthcareAppointmentContext);
        

        public async Task Save()
        {
            await _healthcareAppointmentContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _healthcareAppointmentContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task GetUsersAsync()
        {
            return _healthcareAppointmentContext.Users.ToListAsync();
        }

        Task<List<User>> IUoWUser.GetUsers()
        {
            return _healthcareAppointmentContext.Users.ToListAsync();
        }

        public Task Register(Register registerModel)
        {
            _healthcareAppointmentContext.Registration.Add(registerModel);
            return _healthcareAppointmentContext.SaveChangesAsync();
        }

        public Task<List<UsersWithAppointment>> GetUsersWithAppointment()
        {
            return _healthcareAppointmentContext.UsersWithAppointments.ToListAsync();
        }
    }
}
