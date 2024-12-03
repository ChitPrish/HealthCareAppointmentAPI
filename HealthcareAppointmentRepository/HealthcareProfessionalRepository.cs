using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointmentModels;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentRepository
{
    public class HealthcareProfessionalRepository(HealthcareAppointmentContext healthcareAppointmentContext) : IUowHealthcareProfessional
    {
        public HealthcareAppointmentModels.HealthcareAppointmentContext _healthcareAppointmentContext = healthcareAppointmentContext;

        public void Dispose()
        {
            _healthcareAppointmentContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task<List<HealthcareProfessional>> GetHealthcareProfessionals()
        {
            return _healthcareAppointmentContext.HealthcareProfessionals.ToListAsync();
        }
    }
}
