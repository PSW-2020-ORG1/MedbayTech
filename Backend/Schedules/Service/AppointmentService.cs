using Backend.Schedules.Service.Interfaces;
using Backend.Users.Model;
using Backend.Users.Repository;
using Model.Schedule;
using Model.Users;
using Repository.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Exceptions.Schedules;
using Backend.Schedules.Service.Interfaces;
using Backend.Users.Repository.MySqlRepository;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Backend.Schedules.Service
{
   public class AppointmentService : IAppointmentService
   {
        private const int appointmentDuration = 30;
        IDoctorWorkDayRepository _doctorWorkDayRepository;
        IAppointmentRepository _appointmentRepository;
        ISurveyRepository _surveyRepository;
        public AppointmentService(IDoctorWorkDayRepository doctorWorkDayRepository, IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorWorkDayRepository = doctorWorkDayRepository;
        }
        public AppointmentService(IAppointmentRepository appointmentRepository, ISurveyRepository surveyRepository, IDoctorWorkDayRepository doctorWorkDayRepository)
        {      
            _appointmentRepository = appointmentRepository;
            _surveyRepository = surveyRepository;
            _doctorWorkDayRepository = doctorWorkDayRepository;
        }

        public List<Appointment> GetAllOtherAppointments(string id)
        {
            List<Appointment> allAppointments = _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
            List<Appointment> surveyableAppointments = GetSurveyableAppointments(id);
            List<Appointment> cancelableAppointments = GetCancelableAppointments(id);
            List<Appointment> allOtherAppointments = new List<Appointment>();

            allOtherAppointments = allAppointments.Where(p => !surveyableAppointments.Any(l => p.Id == l.Id)).ToList();
            allOtherAppointments = allOtherAppointments.Where(p => !cancelableAppointments.Any(l => p.Id == l.Id)).ToList();

            return allOtherAppointments;
        }

        public List<Appointment> GetAppointmentsByPatientId(string id)
        {
            return _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
        }

        public List<Appointment> GetCancelableAppointments(string id)
        {
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
            List<Appointment> cancelableAppointments = new List<Appointment>();
            var cancelDays = 2.00;
            cancelableAppointments = appointments.Where(p => !(p.CanceledByPatient) && !(p.Finished) && ((p.Start - DateTime.Now).TotalDays > cancelDays)).ToList();

            return cancelableAppointments;
        }

        public List<Appointment> GetSurveyableAppointments(string id)
        {
            List<Survey> surveys = _surveyRepository.GetAll().ToList();
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
            List<Appointment> surveyableAppointments = new List<Appointment>();
            surveyableAppointments = appointments.Where(p => !surveys.Any(l => p.Id == l.AppointmentId) && p.Finished == true).ToList();
            
            return surveyableAppointments;
        }

        public bool UpdateCanceled(int appointmentId)
        {
            Appointment appointment = _appointmentRepository.GetObject(appointmentId);
            if (appointment == null) {
                return false;
            }
            if (appointment.CanceledByPatient)
            {
                return false;
            }
            appointment.CanceledByPatient = true;
            _appointmentRepository.Update(appointment);
            return true;
        }

        public Appointment ScheduleAppointment(Appointment appointment)
        {
            List<Appointment> available = GetAvailableBy(appointment.DoctorId, appointment.Start);
            bool isAvailable = available.Any(a => a.isOccupied(appointment.Start, appointment.End));
            if (isAvailable)
                return _appointmentRepository.Create(appointment);

            return null;
        }

        public List<Appointment> GetAvailableByDoctorAndDateRange(string doctorId, DateTime start, DateTime end)
        {
            List<Appointment> availableAppointments = new List<Appointment>();
            for (DateTime date = start; date.Date <= end.Date; date = date.AddDays(1))
            {
                availableAppointments.AddRange(GetAvailableBy(doctorId, date));
            }
            return availableAppointments;
        }

        public List<Appointment> GetAvailableBy(string doctorId, DateTime date)
        {
            List<Appointment> occupied = GetByDoctorAndDate(doctorId, date);
            List<Appointment> allAppointments = InitializeAppointments(doctorId, date);
            List<Appointment> available = new List<Appointment>(allAppointments);
            foreach(Appointment appointmentIt in allAppointments)
            {
                Appointment appointment = occupied.FirstOrDefault(a => a.isOccupied(appointmentIt.Start, appointmentIt.End));
                
                if (appointment != null && !appointment.CanceledByPatient)
                    available.Remove(appointmentIt);
            }
            return available;
        }

        public List<Appointment> GetByDoctorAndDate(string doctorId, DateTime date)
        {
            return _appointmentRepository.GetBy(doctorId, date).ToList();
        }

        public List<Appointment> InitializeAppointments(string doctorId, DateTime date)
        {
            List<Appointment> appointments = new List<Appointment>();
            DoctorWorkDay doctorWorkDays = _doctorWorkDayRepository.GetByDoctorIdAndDate(doctorId, date.Date);

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
                    Start = appointmentStart.AddMinutes(appointmentDuration * i),
                    End = appointmentStart.AddMinutes(appointmentDuration * (i + 1))
                };
                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
