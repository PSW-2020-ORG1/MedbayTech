using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistance;
using Application.Common.Interfaces.Service;
using Application.DTO;
using Castle.Core.Internal;
using Domain.Enums;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
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
        private readonly IRoomGateway _roomGateway;
        private readonly ISurveyRepository _surveyRepository;
        private IPriorityStrategy _priorityStrategy;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUserGateway userGateway, IRoomGateway roomGateway, ISurveyRepository surveyRepository)
        {
            _appointmentRepository = appointmentRepository;
            _userGateway = userGateway;
            _roomGateway = roomGateway;
            _surveyRepository = surveyRepository;
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
            List<Survey> surveys = _surveyRepository.GetAll().ToList();
            List<Appointment> appointments = GetAllForPatient(id);
            List<Appointment> surveyableAppointments = new List<Appointment>();
            surveyableAppointments = appointments.Where(p => !surveys.Any(l => p.Id == l.AppointmentId) && p.Finished && !p.CanceledByPatient).ToList();

            return surveyableAppointments; 

            
        } 

        public bool UpdateCanceled(int appointmentId)
        {
            Appointment appointment = GetAppointment(appointmentId);
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
            foreach(Appointment appointment in appointmentsForDays) //22 3:00 
            {
                if (appointment.Period.StartTime >= parameters.ChosenStartDate && appointment.Period.EndTime <= parameters.ChosenEndDate) appointments.Add(appointment);//22:00 22:30
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

        public List<Appointment> GetAppointmentByPatient(string patientId)
        {
            return GetAll().Where(a => a.PatientId != null && a.Patient.Equals(patientId)).ToList();
        }

        public List<Appointment> GetAll()
        {
            var appointments = _appointmentRepository.GetAll();
            foreach (Appointment appointment in appointments)
                BindProperties(appointment);
            return appointments;
        }

        public Appointment GetAppointment(int appointmentId)
        {
            var appointment = _appointmentRepository.GetBy(appointmentId);
            BindProperties(appointment);
            return appointment;
        }
        public List<Appointment> GetAllForPatient(string id)
        {
            var appointments = _appointmentRepository.GetAppointmentsByPatientId(id);
            foreach (Appointment appointment in appointments)
                BindProperties(appointment);
            return appointments;
        }

        private void BindProperties(Appointment appointment)
        {
            appointment.Doctor = _userGateway.GetDoctorBy(appointment.DoctorId);
            appointment.Patient = _userGateway.GetPatientBy(appointment.PatientId);
            appointment.Room = _roomGateway.GetRoomBy(appointment.RoomId);
        }

        public Appointment UpdateSuggestedAppointment(Appointment appointment)
        {
            Appointment update_appointment = _appointmentRepository.GetAll().ToList().Find(a => a.Id == appointment.Id);
            update_appointment.Period.StartTime = appointment.Period.StartTime;
            update_appointment.Period.EndTime = appointment.Period.EndTime;
            update_appointment.TypeOfAppointment = appointment.TypeOfAppointment;
            update_appointment.Urgent = true;
            update_appointment.DoctorId = appointment.DoctorId;
            return _appointmentRepository.Update(update_appointment);
        }

    }
}
