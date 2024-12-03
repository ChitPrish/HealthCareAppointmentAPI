using System;
using System.Collections.Generic;

namespace HealthcareAppointmentModels;

public partial class HealthcareProfessional
{
    public long HealthcareProfessionalId { get; set; }

    public string HealthcareProfessionalsName { get; set; } = null!;

    public string? Specialty { get; set; }

    //public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
