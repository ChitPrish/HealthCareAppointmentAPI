using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointmentModels;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentRepository
{
    public class AppointmentRepository : IUoWAppointment
    {
        private readonly HealthcareAppointmentContext _context;

        public AppointmentRepository(HealthcareAppointmentContext healthcareAppointmentContext) 
        { 
            _context = healthcareAppointmentContext;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task<List<Appointment>> GetAllAppointsByUser(string userName)
        {
            return _context.Appointments.ToListAsync();
        }

        async Task<bool> IUoWAppointment.CancelAppointment(long id, Appointment appointment)
        {
            if (id == appointment.AppointmentId)
            {
                if(appointment.AppointmentStartTime > DateTime.Now.AddHours(24))
                {
                    appointment.AppointmentStatus = (int)BookingStatus.Cancelled;
                    _context.Entry(appointment).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }
        }

        Task<List<Appointment>> IUoWAppointment.GetAllAppoints()
        {
            return _context.Appointments.Where(x => x.AppointmentStatus == (int)BookingStatus.Booked).ToListAsync();
        }

        Task<int> IUoWAppointment.TakeAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            return _context.SaveChangesAsync();
        }
    }
}
