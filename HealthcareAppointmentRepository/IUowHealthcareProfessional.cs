using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointmentModels;

namespace HealthcareAppointmentRepository
{
    public interface IUowHealthcareProfessional: IDisposable
    {
        Task<List<HealthcareProfessional>> GetHealthcareProfessionals();
    }
}
