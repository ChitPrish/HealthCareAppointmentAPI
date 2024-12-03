using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointmentModels;
using HealthcareAppointmentServices.Models;

namespace HealthcareAppointmentServices
{
    public interface IHealthcareProffInterface
    {
        Task<List<HealthcareProfessional>> GetHealthcareProfessionalDetails();
    }
}
