using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareAppointmentAPI.Repository;
using HealthcareAppointmentModels;
using HealthcareAppointmentRepository;
using HealthcareAppointmentServices;

namespace HealthCareAppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly HealthcareAppointmentContext _context;
        private readonly IAppointmentInterface _appointmentInterface;

        public AppointmentsController(HealthcareAppointmentContext context, IAppointmentInterface  appointmentInterface)
        {
            _context = context;
            _appointmentInterface = appointmentInterface; 
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(long id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        private async Task<IActionResult> PutAppointment(long id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("Cancel/{id}")]
        public async Task<IActionResult> CancelAppointmet(long id, Appointment appointment)
        {
            var isCancelled = await _appointmentInterface.CancelAppointment(id, appointment);
            return new ContentResult();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> BookAppointment(AppointmentModel appointment)
        {
            var appointmentId = await _appointmentInterface.BookAppointment(appointment);

            if(appointmentId == -1)
            {
                return Content("Appointment is not available.");
            }
            else if (appointmentId == -2)
            {
                return Content("Appointmnet data is incorrect.");
            }
            else
            {
                return CreatedAtAction("GetAppointment", new { id = appointmentId }, appointment);
            }
            
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        private async Task<IActionResult> DeleteAppointment(long id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(long id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
