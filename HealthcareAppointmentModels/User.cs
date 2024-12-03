using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentModels;
//[Keyless]
public partial class User : Register
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserId { get; set; }

    //public string UserName { get; set; } = null!;

    //public string UserEmail { get; set; } = null!;

    //public string? Password { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    //[NotMapped]
    //public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}

[Keyless]
public class Register : LoginModel
{
    //public string UserName { get; set; } = null!;

    [Required]
    public string UserEmail { get; set; } = null!;

    //public string? Password { get; set; }
}

public class UsersWithAppointment : User
{
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
