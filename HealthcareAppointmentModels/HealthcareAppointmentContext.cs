using System;
using System.Collections.Generic;
using HealthcareAppointmentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace HealthcareAppointmentModels;

public partial class HealthcareAppointmentContext : DbContext
{
    //private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
    public HealthcareAppointmentContext()
    {
    }

    public HealthcareAppointmentContext(DbContextOptions<HealthcareAppointmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<HealthcareProfessional> HealthcareProfessionals { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersWithAppointment> UsersWithAppointments { get; set; }

    public virtual DbSet<Register> Registration { get; set; }


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    DbContext context = new DbContext();
    //    optionsBuilder.UseSqlServer(connectionString)
    //}



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");
            entity.Property(e => e.AppointmentEndTime)
                .HasColumnType("datetime")
                .HasColumnName("appointment_end_time");
            entity.Property(e => e.AppointmentStartTime)
                .HasColumnType("datetime")
                .HasColumnName("appointment_start_time");
            entity.Property(e => e.AppointmentStatus).HasColumnName("appointment_status");
            entity.Property(e => e.HealthcareProfessionalId).HasColumnName("healthcare_professional_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            //entity.HasOne(d => d.HealthcareProfessional).WithMany(p => p.Appointments)
            //    .HasForeignKey(d => d.HealthcareProfessionalId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Appointments_HealthcareProfessional");

            //entity.HasOne(d => d.User).WithMany(p => p.Appointments)
            //    .HasForeignKey(d => d.UserId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Appointments_Users");
        });

        modelBuilder.Entity<HealthcareProfessional>(entity =>
        {
            entity.ToTable("HealthcareProfessional");

            entity.Property(e => e.HealthcareProfessionalId)
                .ValueGeneratedNever()
                .HasColumnName("healthcare_professional_id");
            entity.Property(e => e.HealthcareProfessionalsName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("healthcare_professionals_name");
            entity.Property(e => e.Specialty)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("specialty");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId)
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");
            //entity.Property(e => e.Appointments).ValueGeneratedNever();
          
        });

        modelBuilder.Entity<Register>(entity =>
        {
            //entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
