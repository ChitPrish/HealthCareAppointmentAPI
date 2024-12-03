using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointmentModels;
using HealthcareAppointmentRepository;

namespace HealthcareAppointmentServices
{
    public class HealthcareProfessionalService : IHealthcareProffInterface
    {
        private readonly IUowHealthcareProfessional _heallthcareProfessional;

        public HealthcareProfessionalService(IUowHealthcareProfessional heallthcareProfessional)
        {
            _heallthcareProfessional = heallthcareProfessional;
        }

        public async Task<List<HealthcareProfessional>> GetHealthcareProfessionalDetails()
        {
            var details = await _heallthcareProfessional.GetHealthcareProfessionals();
            return details;
        }
    }
}
