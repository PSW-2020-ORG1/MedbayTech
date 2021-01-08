
using Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedbayTech.Appointment.Infrastructure.Services
{
    public class AppointmentRealocationService : IAppointmentRealocationService
    {
        private const int appointmentDuration = 30;
        private const int alternativeAppointmentTimeSpan = 5;

        IAppointmentRealocationRepository _appointmentRealocationRepository;
        IAppointmentRepository _appointmentRepository;

        public AppointmentRealocationService(IAppointmentRealocationRepository appointmentRealocationRepository, IAppointmentRepository appointmentRepository)
        {
            _appointmentRealocationRepository = appointmentRealocationRepository;
            _appointmentRepository = appointmentRepository;
        }

        public bool CheckIsRoomAvailableInSelectedTime(int roomId, DateTime chosenDateTime)
        {
            AppointmentRealocation appointmentRealocation = _appointmentRealocationRepository.GetAll().ToList().Find(a => a.RoomId == roomId && a.Start == chosenDateTime);
            if (appointmentRealocation == null) return true && !AppointmentIsScheduledAlready(roomId, chosenDateTime);
            else return false;
        }

        public List<AppointmentRealocation> GetAllAvailableAppointmentByRoomAndDateTime(int roomId, DateTime chosenStart, DateTime chosenEnd)
        {
            DateTime start = chosenStart;
            DateTime end = chosenEnd;
            List<AppointmentRealocation> availableAppointments = new List<AppointmentRealocation>();
            for (DateTime date = start; date.Date <= end.Date; date = date.AddDays(1))
            {
                availableAppointments.AddRange(GetAvailableBy(roomId, date));
            }
            return availableAppointments;
        }

        private List<AppointmentRealocation> GetAvailableBy(int roomId, DateTime date)
        {
            if(AppointmentIsScheduledAlready(roomId,date)) return new List<AppointmentRealocation>();
            List<AppointmentRealocation> occupied = GetByRoomAndDate(roomId, date);
            List<AppointmentRealocation> allAppointments = InitializeAppointments(roomId, date);
            List<AppointmentRealocation> available = new List<AppointmentRealocation>(allAppointments);
            foreach (AppointmentRealocation appointmentIt in allAppointments)
            {
                AppointmentRealocation appointment = occupied.FirstOrDefault(a => a.isOccupied(appointmentIt.Start, appointmentIt.End));
                if (appointment != null) available.Remove(appointmentIt);
            }
            return available;
        }

        private bool AppointmentIsScheduledAlready(int roomId, DateTime date)
        {
            MedbayTech.Appointment.Domain.Entities.Appointment checkIfAppointment = _appointmentRepository.GetAll().ToList().Find(a => a.RoomId == roomId && a.Start == date);
            if (checkIfAppointment == null) return false;
            else return true;
        }
        public List<AppointmentRealocation> GetByRoomAndDate(int roomId, DateTime date)
        {
            return _appointmentRealocationRepository.GetBy(roomId, date);
        }

        private List<AppointmentRealocation> InitializeAppointments(int roomId, DateTime date)
        {
            List<AppointmentRealocation> appointments = new List<AppointmentRealocation>();
            DateTime appointmentStart = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime appointmentEnd = appointmentStart.AddDays(1);
            for (DateTime start = appointmentStart; start < appointmentEnd; start = start.AddMinutes(appointmentDuration))
            {
                if(start >= DateTime.Now)
                {
                    AppointmentRealocation appointment = new AppointmentRealocation
                    {
                        RoomId = roomId,
                        Start = start,
                        End = start.AddMinutes(appointmentDuration)
                    };
                    appointments.Add(appointment);
                }            
            }
            return appointments;
        }

        public AppointmentRealocation ScheduleAppointmentRealocation(AppointmentRealocation appointmentRealocation)
        {
            return _appointmentRealocationRepository.Create(appointmentRealocation);
        }

        public List<AppointmentRealocation> GetAlternativeAvailableAppointments(int fromRoomId, int toRoomId, DateTime dateTime, int hospitalEquipmentId)
        {
            List<AppointmentRealocation> alternativeAppointmetns = new List<AppointmentRealocation>();
            List<AppointmentRealocation> appointmentRealocationsFromRoom = GetAllAvailableAppointmentByRoomAndDateTime(fromRoomId, dateTime, dateTime.AddDays(alternativeAppointmentTimeSpan));
            List<AppointmentRealocation> appointmentRealocationsToRoom = GetAllAvailableAppointmentByRoomAndDateTime(toRoomId, dateTime, dateTime.AddDays(alternativeAppointmentTimeSpan));
            foreach(AppointmentRealocation appointmentFrom in appointmentRealocationsFromRoom)
            {
                if (CheckForMatchingAppointments(appointmentFrom, appointmentRealocationsToRoom)) alternativeAppointmetns.Add(appointmentFrom);
            }
            foreach(AppointmentRealocation appointment in alternativeAppointmetns)
            {
                appointment.HospitalEquipmentId = hospitalEquipmentId;
            }
            return alternativeAppointmetns;
        }

        private bool CheckForMatchingAppointments(AppointmentRealocation appointment, List<AppointmentRealocation> appointmentRealocationsToRoom)
        {
            foreach (AppointmentRealocation appointmentTo in appointmentRealocationsToRoom)
            {
                if(appointment.Start == appointmentTo.Start)
                {
                    return true;
                }
            }
            return false;
        }

        List<AppointmentRealocation> IAppointmentRealocationService.GetAllAvailableAppointmentByRoomAndDateTime(int roomId, DateTime chosenStart, DateTime chosenEnd)
        {
            throw new NotImplementedException();
        }

        public AppointmentRealocation ScheduleAppointmentRealocation(AppointmentRealocation appointmentRealocation)
        {
            throw new NotImplementedException();
        }

        List<AppointmentRealocation> IAppointmentRealocationService.GetAlternativeAvailableAppointments(int fromRoomId, int toRoomId, DateTime dateTime, int hospitalEquipmentId)
        {
            throw new NotImplementedException();
        }
    }
}
