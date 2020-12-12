using Backend.Schedules.Service.Interfaces;
using Backend.Users.Model;
using Backend.Users.Repository;
using Model.Schedule;
using Model.Users;
using Repository.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Rooms.Service;
using Backend.Schedules.Service.StrategyPattern;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Service.ScheduleService;

namespace Backend.Schedules.Service
{
    public class AppointmentService : IAppointmentService
    {
        private const int appointmentDuration = 30;
        IDoctorWorkDayRepository _doctorWorkDayRepository;
        IAppointmentRepository _appointmentRepository;
        IDoctorService _doctorService;

        private IPriorityStrategy _priorityStrategy;

        public AppointmentService(IDoctorWorkDayRepository doctorWorkDayRepository, IAppointmentRepository appointmentRepository, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _doctorWorkDayRepository = doctorWorkDayRepository;
            _doctorService = doctorService;
        }

        public Appointment ScheduleAppointment(Appointment appointment)
        {
            List<Appointment> available = GetAvailableBy(appointment.DoctorId, appointment.Start);
            bool isAvailable = available.Any(a => a.isOccupied(appointment.Start, appointment.End));
            if (isAvailable)
                return _appointmentRepository.Create(appointment);

            return null;
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
                Appointment appointment = occupied.FirstOrDefault(a => a.isOccupied(appointmentIt.Start, appointmentIt.End));
                
                if (appointment != null && !appointment.canceledByPatient)
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
                    Start = appointmentStart.AddMinutes(appointmentDuration * i),
                    End = appointmentStart.AddMinutes(appointmentDuration * (i + 1))
                };
                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
