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
    public class HealthcareProfessionalsController : ControllerBase
    {
        private readonly HealthcareAppointmentContext _context;

        private readonly IHealthcareProffInterface _healthcareProffInterface;

        public HealthcareProfessionalsController(HealthcareAppointmentContext context, IHealthcareProffInterface heallthcareProffInterface)
        {
            _context = context;
            _healthcareProffInterface = heallthcareProffInterface;
        }

        // GET: api/HealthcareProfessionals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthcareProfessional>>> GetHealthcareProfessionals()
        {
            var details = await _healthcareProffInterface.GetHealthcareProfessionalDetails();
            return details.ToList();
            //return await _context.HealthcareProfessionals.ToListAsync();
        }

        // GET: api/HealthcareProfessionals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthcareProfessional>> GetHealthcareProfessional(long id)
        {
            var healthcareProfessional = await _context.HealthcareProfessionals.FindAsync(id);

            if (healthcareProfessional == null)
            {
                return NotFound();
            }

            return healthcareProfessional;
        }

        // PUT: api/HealthcareProfessionals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthcareProfessional(long id, HealthcareProfessional healthcareProfessional)
        {
            if (id != healthcareProfessional.HealthcareProfessionalId)
            {
                return BadRequest();
            }

            _context.Entry(healthcareProfessional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthcareProfessionalExists(id))
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

        // POST: api/HealthcareProfessionals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HealthcareProfessional>> PostHealthcareProfessional(HealthcareProfessional healthcareProfessional)
        {
            _context.HealthcareProfessionals.Add(healthcareProfessional);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HealthcareProfessionalExists(healthcareProfessional.HealthcareProfessionalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHealthcareProfessional", new { id = healthcareProfessional.HealthcareProfessionalId }, healthcareProfessional);
        }

        // DELETE: api/HealthcareProfessionals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthcareProfessional(long id)
        {
            var healthcareProfessional = await _context.HealthcareProfessionals.FindAsync(id);
            if (healthcareProfessional == null)
            {
                return NotFound();
            }

            _context.HealthcareProfessionals.Remove(healthcareProfessional);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HealthcareProfessionalExists(long id)
        {
            return _context.HealthcareProfessionals.Any(e => e.HealthcareProfessionalId == id);
        }
    }
}
