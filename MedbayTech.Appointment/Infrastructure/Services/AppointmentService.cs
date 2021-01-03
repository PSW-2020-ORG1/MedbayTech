using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistance;
using Application.Common.Interfaces.Service;
using Application.DTO;
using Castle.Core.Internal;
using Domain.Enums;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Domain.ValueObjects;

namespace Infrastructure.Services
{
   public class AppointmentService : IAppointmentService
   {
        private const int appointmentDuration = 30;
        private const int datePriorityRange = 2;
        private const int daysBeforeCantBeCanceled = 2;

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserGateway _userGateway;

        private IPriorityStrategy _priorityStrategy;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUserGateway userGateway)
        {
            _appointmentRepository = appointmentRepository;
            _userGateway = userGateway;
        }

        public List<Appointment> GetAllOtherAppointments(string id)
        {
            List<Appointment> allAppointments = GetAllForPatient(id).ToList();
            List<Appointment> surveyableAppointments = GetSurveyableAppointments(id);
            List<Appointment> cancelableAppointments = GetCancelableAppointments(id);
            List<Appointment> allOtherAppointments = new List<Appointment>();

            allOtherAppointments = allAppointments.Where(p => !surveyableAppointments.Any(l => p.Id == l.Id)).ToList();
            allOtherAppointments = allOtherAppointments.Where(p => !cancelableAppointments.Any(l => p.Id == l.Id)).ToList();

            return allOtherAppointments;
        }

        public List<Appointment> GetAppointmentsByPatientId(string id)
        {
            return GetAllForPatient(id).ToList();
        }

        public List<Appointment> GetCancelableAppointments(string id)
        {
            List<Appointment> appointments = GetAllForPatient(id).ToList();
            List<Appointment> cancelableAppointments = new List<Appointment>();
            cancelableAppointments = appointments.Where(p => !(p.CanceledByPatient) && !(p.Finished) && ((p.Period.StartTime - DateTime.Now).TotalDays > daysBeforeCantBeCanceled)).ToList();

            return cancelableAppointments;
        }

        public List<Appointment> GetSurveyableAppointments(string id)
        {
             /*List<Survey> surveys = _surveyRepository.GetAll().ToList();
             List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
             List<Appointment> surveyableAppointments = new List<Appointment>();
             surveyableAppointments = appointments.Where(p => !surveys.Any(l => p.Id == l.AppointmentId) && p.Finished == true).ToList();

             return surveyableAppointments; */

            throw new NotImplementedException();
        } 

        public bool UpdateCanceled(int appointmentId)
        {
            Appointment appointment = _appointmentRepository.GetBy(appointmentId);
            if (appointment == null) {
                return false;
            }
            if (appointment.CanceledByPatient)
            {
                return false;
            }
            appointment.CanceledByPatient = true;
            appointment.CancelationDate = DateTime.Now;
            _appointmentRepository.Update(appointment);
            return true;
        }
   
        public Appointment ScheduleAppointment(Appointment appointment)
        {
            List<Appointment> available = GetAvailableBy(appointment.DoctorId, appointment.Period.StartTime);
            bool isAvailable = available.Any(a => a.IsOccupied(appointment.Period.StartTime, appointment.Period.EndTime));
            if (isAvailable)
                return _appointmentRepository.Create(appointment);
            return null;
        }

        public List<Appointment> GetAvailableByPriorityDoctor(PriorityParameters parameters)
        {
            parameters.ChosenStartDate = parameters.ChosenStartDate.AddDays(-datePriorityRange);
            parameters.ChosenEndDate = parameters.ChosenEndDate.AddDays(datePriorityRange);
            List<Appointment> appointments = GetAvailableByDoctorAndDateRange(parameters);
            return appointments;
        }
        public List<Appointment> GetAvailableByDoctorAndTimeInterval(PriorityParameters parameters)
        {
            List<Appointment> appointmentsForDays = GetAvailableByDoctorAndDateRange(parameters);
            List<Appointment> appointments = new List<Appointment>();
            foreach(Appointment appointment in appointmentsForDays)
            {
                if (appointment.Period.StartTime >= parameters.ChosenStartDate && appointment.Period.EndTime <= parameters.ChosenEndDate) appointments.Add(appointment);
            }
            return appointments;
        }
        public List<Appointment> GetApppointmentsScheduledForSpecificRoom(int roomId)
        {
            return _appointmentRepository.GetAll().ToList().Where(a => a.RoomId == roomId).ToList();
        }

        public List<Appointment> GetAvailableByDoctorAndDateRange(PriorityParameters parameters)
        {
            DateTime start = parameters.ChosenStartDate;
            DateTime end = parameters.ChosenEndDate;
            List<Appointment> availableAppointments = new List<Appointment>();
            for (DateTime date = start; date.Date <= end.Date; date = date.AddDays(1))
            {
                availableAppointments.AddRange(GetAvailableBy(parameters.DoctorId, date));
            }

            return availableAppointments;
        }

        public List<Appointment> GetAvailableByStrategy(PriorityParameters parameters)
        {
             List<Appointment> appointments = GetAvailableByDoctorAndDateRange(parameters);
             if (appointments.IsNullOrEmpty())
             {
                 SwitchStrategy(parameters.Priority);
                 appointments.AddRange(_priorityStrategy.Recommend(parameters));
             }

             return AddDoctors(appointments); 

        }
        private void SwitchStrategy(PriorityType priorityType)
        {
             if(priorityType == PriorityType.doctor)
                 _priorityStrategy = new DoctorPriorityStrategy(this);
             else 
                 _priorityStrategy = new DatePriorityStrategy(this, _userGateway); 

            throw new NotImplementedException();
        }
        public List<Appointment> GetAvailableBy(string doctorId, DateTime date)
        {
            List<Appointment> occupied = GetByDoctorAndDate(doctorId, date);
            List<Appointment> allAppointments = InitializeAppointments(doctorId, date);
            List<Appointment> available = new List<Appointment>(allAppointments);
            foreach(Appointment appointmentIt in allAppointments)
            {
                Appointment appointment = occupied.FirstOrDefault(a => a.IsOccupied(appointmentIt.Period.StartTime, appointmentIt.Period.EndTime) && !a.CanceledByPatient);
                
                if (appointment != null)
                    available.Remove(appointmentIt);
            }

            return available;
        }
        public List<Appointment> GetByDoctorAndDate(string doctorId, DateTime date)
        {
            var appointments = _appointmentRepository.GetBy(doctorId, date).ToList();
            foreach (Appointment appointment in appointments)
            {
                appointment.Doctor = _userGateway.GetDoctorBy(appointment.DoctorId);
                appointment.Patient = _userGateway.GetPatientBy(appointment.PatientId);
            }
            return appointments;
        }

        public List<Appointment> AddDoctors(List<Appointment> appointments)
        {
             foreach (Appointment appointmentIt in appointments)
             {
                 appointmentIt.Doctor = _userGateway.GetDoctorBy(appointmentIt.DoctorId);
             }

             return appointments; 
        }
        public List<Appointment> InitializeAppointments(string doctorId, DateTime date)
        {
              List<Appointment> appointments = new List<Appointment>();
              WorkDay doctorWorkDays = _userGateway.GetWorkDayBy(doctorId, date.Date);

              if (doctorWorkDays == null)
                  return appointments;

              int startTime = doctorWorkDays.StartTime;
              int endTime = doctorWorkDays.EndTime;
              DateTime appointmentStart = new DateTime(date.Year, date.Month, date.Day, startTime, 0, 0);

              for (int i = 0; i < endTime - 1; i++)
              {
                  Appointment appointment = new Appointment
                  {
                      DoctorId = doctorId,
                      Doctor = doctorWorkDays.Doctor,
                      Period = new Period(appointmentStart.AddMinutes(appointmentDuration * i), appointmentStart.AddMinutes(appointmentDuration * (i + 1)))
                  };
                  appointments.Add(appointment);
              }
              return appointments; 
        }

        public List<Appointment> GetAll()
        {
            var appointments = _appointmentRepository.GetAll();
            foreach (Appointment appointment in appointments)
            {
                appointment.Doctor = _userGateway.GetDoctorBy(appointment.DoctorId);
                appointment.Patient = _userGateway.GetPatientBy(appointment.PatientId);
            }
            return appointments;
        }

        public List<Appointment> GetAppointmentsBy(string userId)
        {
            return GetAll().Where(a => a.PatientId != null && a.Patient.Equals(userId)).ToList();
        }

        public List<Appointment> GetAllForPatient(string id)
        {
            var appointments = _appointmentRepository.GetAppointmentsByPatientId(id);
            foreach (Appointment appointment in appointments)
            {
                appointment.Doctor = _userGateway.GetDoctorBy(appointment.DoctorId);
                appointment.Patient = _userGateway.GetPatientBy(appointment.PatientId);
            }
            return appointments;
        }

    }
}
