using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentModels;


public partial class Appointment
{
    public long AppointmentId { get; set; }

    public long UserId { get; set; }

    public long HealthcareProfessionalId { get; set; }

    public DateTime? AppointmentStartTime { get; set; }

    public DateTime? AppointmentEndTime { get; set; }

    public int? AppointmentStatus { get; set; }

    //public virtual HealthcareProfessional HealthcareProfessional { get; set; } = null!;

    //public virtual User User { get; set; } = null!;
}

public class AppointmentModel
{
    private BookingStatus bookingStatus;

    public required string UserName { get; set; }

    public required string HealthcareProfessionalName { get; set; }

    public required DateTime StartTime { get; set; }

    public required DateTime EndTime { get; set; }

    public BookingStatus BookingStatus { get => bookingStatus; set => bookingStatus = value; }
}

public enum BookingStatus
{
    Booked,
    Completed,
    Cancelled
}
