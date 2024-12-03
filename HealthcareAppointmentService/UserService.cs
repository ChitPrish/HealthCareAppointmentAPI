using HealthcareAppointmentModels;
using HealthcareAppointmentServices;
using HealthcareAppointmentServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HealthcareAppointmentRepository
{
    public class UserService : IUserInterface
    {
        private readonly IUoWUser _user;
        private readonly IUoWAppointment _appointment;
        public UserService(IUoWUser uowUser, IUoWAppointment appointment)
        {
            _user = uowUser;
            _appointment = appointment;
        }

        public async Task<List<UserDetails>> GetUserDetails()
        {
            var userDetails = await _user.GetUsers();
            List<UserDetails> users = new List<UserDetails>();
            if (userDetails.Count > 0)
            {
                foreach (var user in userDetails)
                {
                    UserDetails userInfo = new()
                    { Email = user.UserEmail, Name = user.UserName };
                    users.Add(userInfo);
                }
            }
            return users;
        }

        public async Task<List<UserDetailsWithId>> GetUserDetailsWithId()
        {
            var userDetails = await _user.GetUsers();
            List<UserDetailsWithId> users = new List<UserDetailsWithId>();
            if (userDetails.Count > 0)
            {
                foreach (var user in userDetails)
                {
                    UserDetailsWithId userInfo = new()
                    {
                        UserId = user.UserId,
                        Email = user.UserEmail, 
                        Name = user.UserName 
                    };
                    users.Add(userInfo);
                }
            }
            return users;
        }

        async Task<List<UsersWithAppointment>> IUserInterface.GetUserWithAppointments()
        {
            var users =  await _user.GetUsersWithAppointment();
            foreach(var user in users)
            {
                user.Appointments = _appointment.GetAllAppointsByUser(user.UserName).Result;
            }
            return users;
        }
    }
}
