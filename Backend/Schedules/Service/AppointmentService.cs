using Backend.Schedules.Service.Interfaces;
using Backend.Users.Model;
using Backend.Users.Repository;
using Model.Schedule;
using Model.Users;
using Repository.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Users.Repository.MySqlRepository;
using Backend.Rooms.Service;
using Backend.Schedules.Service.StrategyPattern;
using Castle.Core.Internal;
using Service.ScheduleService;

namespace Backend.Schedules.Service
{
   public class AppointmentService : IAppointmentService
   {
        private const int appointmentDuration = 30;
        private const int datePriorityRange = 2;
        private const int daysBeforeCantBeCanceled = 2;

        IDoctorWorkDayRepository _doctorWorkDayRepository;
        IAppointmentRepository _appointmentRepository;
        ISurveyRepository _surveyRepository;
        IDoctorService _doctorService;

        private IPriorityStrategy _priorityStrategy;

        public AppointmentService(IDoctorWorkDayRepository doctorWorkDayRepository, IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorWorkDayRepository = doctorWorkDayRepository;
        }

        public AppointmentService(IDoctorWorkDayRepository doctorWorkDayRepository, IAppointmentRepository appointmentRepository, IDoctorService doctorService, ISurveyRepository surveyRepository){
            _appointmentRepository = appointmentRepository;
            _surveyRepository = surveyRepository;
            _doctorWorkDayRepository = doctorWorkDayRepository;
            _doctorService = doctorService;
        }
        public AppointmentService(IDoctorWorkDayRepository doctorWorkDayRepository, IAppointmentRepository appointmentRepository, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _doctorWorkDayRepository = doctorWorkDayRepository;
            _doctorService = doctorService;
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
            cancelableAppointments = appointments.Where(p => !(p.CanceledByPatient) && !(p.Finished) && ((p.Start - DateTime.Now).TotalDays > daysBeforeCantBeCanceled)).ToList();

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
            appointment.CancelationDate = DateTime.Now;
            _appointmentRepository.Update(appointment);
            return true;


        }
   
        public Appointment ScheduleAppointment(Appointment appointment)
        {
            List<Appointment> available = GetAvailableBy(appointment.DoctorId, appointment.Start);
            appointment.PatientId = "2406978890046";
            bool isAvailable = available.Any(a => a.isOccupied(appointment.Start, appointment.End));
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
                if (appointment.Start >= parameters.ChosenStartDate && appointment.End <= parameters.ChosenEndDate) appointments.Add(appointment);
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
                _priorityStrategy = new DatePriorityStrategy(this, _doctorService);
        }
        public List<Appointment> GetAvailableBy(string doctorId, DateTime date)
        {
            List<Appointment> occupied = GetByDoctorAndDate(doctorId, date);
            List<Appointment> allAppointments = InitializeAppointments(doctorId, date);
            List<Appointment> available = new List<Appointment>(allAppointments);
            foreach(Appointment appointmentIt in allAppointments)
            {
                Appointment appointment = occupied.FirstOrDefault(a => a.isOccupied(appointmentIt.Start, appointmentIt.End) && !a.CanceledByPatient);
                
                if (appointment != null)
                    available.Remove(appointmentIt);
            }

            return available;
        }
        public List<Appointment> GetByDoctorAndDate(string doctorId, DateTime date)
        {
            return _appointmentRepository.GetBy(doctorId, date).ToList();
        }

        public List<Appointment> AddDoctors(List<Appointment> appointments)
        {
            foreach (Appointment appointmentIt in appointments)
            {
                appointmentIt.Doctor = _doctorService.GetDoctorBy(appointmentIt.DoctorId);
            }

            return appointments;
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
                    Doctor = doctorWorkDays.Doctor,
                    Start = appointmentStart.AddMinutes(appointmentDuration * i),
                    End = appointmentStart.AddMinutes(appointmentDuration * (i + 1))
                };
                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
