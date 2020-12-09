﻿using Backend.Schedules.Service.Interfaces;
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
using Backend.Users.WebApiService;
using Repository.RoomRepository;
using Model.Rooms;

namespace Backend.Schedules.Service
{
    public class AppointmentService : IAppointmentService
    {
        private const int appointmentDuration = 30;
        IDoctorWorkDayRepository _doctorWorkDayRepository;
        IAppointmentRepository _appointmentRepository;
        IDoctorRepository _doctorRepository;
        IHospitalEquipmentRepository _hospitalEquipmentRepository;

        public AppointmentService(IDoctorWorkDayRepository doctorWorkDayRepository, IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IHospitalEquipmentRepository hospitalEquipmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorWorkDayRepository = doctorWorkDayRepository;
            _doctorRepository = doctorRepository;
            _hospitalEquipmentRepository = hospitalEquipmentRepository;
        }

        public Appointment ScheduleAppointment(Appointment appointment)
        {
            List<Appointment> available = GetAvailableBy(appointment.DoctorId, appointment.Start);
            bool isAvailable = available.Any(a => a.isOccupied(appointment.Start, appointment.End));
            if (isAvailable)
                return _appointmentRepository.Create(appointment);

            return null;
        }
        public List<Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(string doctorId, int hospitalEquipmentId, DateTime startTime, DateTime endTime, string priority)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<Appointment> allAppointments;
            if(priority.Equals("doctor"))
            {
                allAppointments = GetAvailableByPriorityDoctor(doctorId, startTime, endTime);
            }
            else if(priority.Equals("timeinterval"))
            {
                allAppointments = GetAvailableByPriorityTimeInterval(startTime, endTime);
            }
            else
            {
                allAppointments = GetAvailableByDoctorAndTimeInterval(doctorId, startTime, endTime);
            }
            HospitalEquipment hospitalEquipment = _hospitalEquipmentRepository.GetObject(hospitalEquipmentId);
            foreach(Appointment appointment in allAppointments)
            {
                if (appointment.Room.Id == hospitalEquipment.RoomId) appointments.Add(appointment);
            }
            return appointments;
        }
        public List<Appointment> GetAvailableByPriorityDoctor(string doctorId, DateTime startTime, DateTime endTime)
        {
            DateTime newStartTime = startTime.AddDays(-2);
            DateTime newEndTime = endTime.AddDays(2);
            List<Appointment> appointments = GetAvailableByDoctorAndDateRange(doctorId, newStartTime, newEndTime);
            return appointments;
        }
        public List<Appointment> GetAvailableByPriorityTimeInterval(DateTime startTime, DateTime endTime)
        {
            List<Appointment> appointmentsForAllDoctors = new List<Appointment>();
            foreach (Doctor doctor in _doctorRepository.GetAll())
            {
                appointmentsForAllDoctors.AddRange(GetAvailableByDoctorAndTimeInterval(doctor.Id, startTime, endTime));
            }
            
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in appointmentsForAllDoctors)
            {
                if (appointment.Start >= startTime && appointment.End <= endTime) appointments.Add(appointment);
            }
            return appointments;
        }
        public List<Appointment> GetAvailableByDoctorAndTimeInterval(string doctorId, DateTime startTime, DateTime endTime)
        {
            List<Appointment> appointmentsForDays = GetAvailableByDoctorAndDateRange(doctorId, startTime, endTime);
            List<Appointment> appointments = new List<Appointment>();
            foreach(Appointment appointment in appointmentsForDays)
            {
                if (appointment.Start >= startTime && appointment.End <= endTime) appointments.Add(appointment);
            }
            return appointments;
        }
        public List<Appointment> GetApppointmentsScheduledForSpecificRoom(int roomId)
        {
            return _appointmentRepository.GetAll().ToList().Where(a => a.RoomId == roomId).ToList();
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
                
                if (appointment != null && !appointment.canceledByPatient)
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
                    Id = 7 + i,
                    DoctorId = doctorId,
                    Doctor = doctorWorkDays.Doctor,
                    RoomId = doctorWorkDays.Doctor.ExaminationRoom.Id,
                    Room = doctorWorkDays.Doctor.ExaminationRoom,
                    Start = appointmentStart.AddMinutes(appointmentDuration * i),
                    End = appointmentStart.AddMinutes(appointmentDuration * (i + 1))
                };
                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
