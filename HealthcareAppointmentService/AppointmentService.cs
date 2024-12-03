using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging;
using HealthcareAppointmentModels;
using HealthcareAppointmentRepository;
using HealthcareAppointmentServices.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentServices
{
    public class AppointmentService: IAppointmentInterface
    {
        private bool disposedValue;

        private readonly IUserInterface _userInterface;
        private readonly IHealthcareProffInterface _healthcareProff;
        //private readonly IAppointmentInterface _appointmentInterface;
        private readonly IUoWAppointment _IuoWappointment;

        public AppointmentService(IUserInterface userInterface, IHealthcareProffInterface healthcareProff, IUoWAppointment iuoWappointment)
        {
            _userInterface = userInterface;
            _healthcareProff = healthcareProff;
            _IuoWappointment = iuoWappointment; 
        }

        async Task<int> IAppointmentInterface.BookAppointment(AppointmentModel appointmentModel)
        {
            if (appointmentModel != null)
            {
                //Get HealthcareProfessionalId from HealthcareProfessional Table
                long healthcareProfessionalId = GetHealthcareProfessionalId(appointmentModel.HealthcareProfessionalName);

                //Get UserId from Users Table
                long userId = GetUserId(appointmentModel.UserName);

                if(IsHealthcareProfessionalAvailable(appointmentModel) && appointmentModel.StartTime.Date > DateTime.Now.Date)
                {
                    Appointment appoint = new()
                    {
                        AppointmentId = 0,
                        UserId = userId,
                        HealthcareProfessionalId = healthcareProfessionalId,
                        AppointmentStartTime = appointmentModel.StartTime,
                        AppointmentEndTime = appointmentModel.EndTime,
                        AppointmentStatus = (int)BookingStatus.Booked
                    };

                    return await _IuoWappointment.TakeAppointment(appoint);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

        public Task<bool> CancelAppointment(long id, Appointment appointment)
        {
            return _IuoWappointment.CancelAppointment(id, appointment);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        Task<List<Appointment>> IAppointmentInterface.GetAllAppointments()
        {
           return  _IuoWappointment.GetAllAppoints();
        }

        private long GetUserId(string userName)
        {
            long userId = 0;
            var userDetails =  _userInterface.GetUserDetailsWithId();
            if (userDetails != null)
            {
                userId = userDetails.Result.FirstOrDefault(x => x.Name.ToLower() == userName.ToLower()).UserId;
            }
            return userId;
        }

        private long GetHealthcareProfessionalId (string healthcareProfName)
        {
            long healthcareProfessionalId = 0;
            //string healthcareProfName = model.HealthcareProfessionalName;
            var healthcareProffs =  _healthcareProff.GetHealthcareProfessionalDetails();
            if (healthcareProffs != null)
            {
                healthcareProfessionalId = healthcareProffs.Result.FirstOrDefault(x => x.HealthcareProfessionalsName == healthcareProfName).HealthcareProfessionalId;
            }
            return healthcareProfessionalId;
        }

        private bool IsHealthcareProfessionalAvailable(AppointmentModel model)
        {
            bool isAvailable = false;
            long healthcareProfessionalId = 0;
            if (model!= null)
            {
                healthcareProfessionalId = GetHealthcareProfessionalId(model.HealthcareProfessionalName);
                isAvailable = _IuoWappointment.GetAllAppoints().Result
                    .Any(x => x.HealthcareProfessionalId == healthcareProfessionalId
                    &&  x.AppointmentStartTime < model.EndTime && x.AppointmentEndTime > model.StartTime
                    );
            }
            return !isAvailable;
        }

        async Task<List<Appointment>> IAppointmentInterface.GetAllAppointsByUser(string userName)
        {
            long userId = GetUserId(userName);
            return (await _IuoWappointment.GetAllAppoints()).Where(x => x.UserId == userId).ToList();
        }
    }
}
