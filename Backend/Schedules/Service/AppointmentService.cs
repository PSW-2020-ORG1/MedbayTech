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
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Backend.Schedules.Service
{
    public class AppointmentService : IAppointmentService
    {
        IDoctorWorkDayRepository _doctorWorkDayRepository;
        IAppointmentRepository _appointmentRepository;
        public AppointmentService(IDoctorWorkDayRepository doctorWorkDayRepository, IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorWorkDayRepository = doctorWorkDayRepository;
        }

        public Appointment ScheduleAppointment(Appointment appointment)
        {
            List<Appointment> available = GetAvailableByDoctorAndDate(appointment.DoctorId, appointment.Start);
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
                availableAppointments.AddRange(GetAvailableByDoctorAndDate(doctorId, date));
            }
            return availableAppointments;
        }
        public List<Appointment> GetAvailableByDoctorAndDate(string doctorId, DateTime date)
        {
            List<Appointment> occupied = GetByDoctorAndDate(doctorId, date);
            List<Appointment> allAppointments = InitializeAppointments(doctorId, date);
            List<Appointment> available = new List<Appointment>(allAppointments);
            foreach(Appointment appointmentIt in allAppointments)
            {
                Appointment appointment = occupied.FirstOrDefault(a => a.isOccupied(appointmentIt.Start, appointmentIt.End));
                if (isOccupied(appointment))
                    available.Remove(appointmentIt);
            }
            return available;
        }
        private bool isOccupied(Appointment appointment)
        {
            return appointment != null && !appointment.canceledByPatient;
        }
    
        public List<Appointment> GetByDoctorAndDate(string doctorId, DateTime date)
        {
            return _appointmentRepository.GetByDoctorIdAndDate(doctorId, date).ToList();
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
            int appointmentDuration = 30;
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
