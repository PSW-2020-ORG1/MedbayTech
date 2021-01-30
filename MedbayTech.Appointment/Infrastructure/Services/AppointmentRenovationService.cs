using Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Services
{
    public class AppointmentRenovationService : IAppointmentRenovationService
    {
        private const int appointmentDuration = 30;

        IAppointmentRenovationRepository _AppointmentRenovationRepository;
        IAppointmentRepository _appointmentRepository;

        public AppointmentRenovationService(IAppointmentRenovationRepository AppointmentRenovationRepository, IAppointmentRepository appointmentRepository)
        {
            _AppointmentRenovationRepository = AppointmentRenovationRepository;
            _appointmentRepository = appointmentRepository;
        }

        public List<AppointmentRenovation> GetAllAvailableAppointmentByRoomAndDateTime(int roomId, DateTime chosenStart, DateTime chosenEnd)
        {
            DateTime start = chosenStart;
            DateTime end = chosenEnd;
            List<AppointmentRenovation> availableAppointments = new List<AppointmentRenovation>();
            for (DateTime date = start; date.Date <= end.Date; date = date.AddDays(1))
            {
                availableAppointments.AddRange(GetAvailableBy(roomId, date));
            }
            return availableAppointments;
        }

        private List<AppointmentRenovation> GetAvailableBy(int roomId, DateTime date)
        {
            if (AppointmentIsScheduledAlready(roomId, date)) return new List<AppointmentRenovation>();
            List<AppointmentRenovation> occupied = GetByRoomAndDate(roomId, date);
            List<AppointmentRenovation> allAppointments = InitializeAppointments(roomId, date);
            List<AppointmentRenovation> available = new List<AppointmentRenovation>(allAppointments);
            foreach (AppointmentRenovation appointmentIt in allAppointments)
            {
                AppointmentRenovation appointment = occupied.FirstOrDefault(a => a.isOccupied(appointmentIt.Period));
                if (appointment != null) available.Remove(appointmentIt);
            }
            return available;
        }

        private bool AppointmentIsScheduledAlready(int roomId, DateTime date)
        {
            MedbayTech.Appointment.Domain.Entities.Appointment checkIfAppointment = _appointmentRepository.GetAll().ToList().Find(a => a.RoomId == roomId && a.Period.StartTime == date);
            if (checkIfAppointment == null) return false;
            else return true;
        }
        public List<AppointmentRenovation> GetByRoomAndDate(int roomId, DateTime date)
        {
            return _AppointmentRenovationRepository.GetBy(roomId, date);
        }

        private List<AppointmentRenovation> InitializeAppointments(int roomId, DateTime date)
        {
            List<AppointmentRenovation> appointments = new List<AppointmentRenovation>();
            DateTime appointmentStart = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime appointmentEnd = appointmentStart.AddDays(1);
            for (DateTime start = appointmentStart; start < appointmentEnd; start = start.AddMinutes(appointmentDuration))
            {
                if (start >= DateTime.Now)
                {
                    AppointmentRenovation appointment = new AppointmentRenovation
                    {
                        RoomId = roomId,
                        Period = new Period() { StartTime = start, EndTime = start.AddMinutes(appointmentDuration) }
                    };
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public AppointmentRenovation ScheduleAppointmentRenovation(AppointmentRenovation appointmentRenovation)
        {
            return _AppointmentRenovationRepository.Create(appointmentRenovation);
        }

        public List<AppointmentRenovation> GetAppointmentRenovationsByRoomId(int roomId)
        {
            return _AppointmentRenovationRepository.GetAll().ToList().Where(a => a.RoomId == roomId && a.IsCanceled == false && a.Finished == false).ToList();
        }

        public AppointmentRenovation UpdateAppointement(AppointmentRenovation appointmentRenovation)
        {
            return _AppointmentRenovationRepository.Update(appointmentRenovation);
        }

        public List<AppointmentRenovation> GetAvailableAppointmentRenovationsForTwoRoms(int roomOneId, int roomTwoId, DateTime start, DateTime end)
        {
            List<AppointmentRenovation> AppointmentRenovationsForRoomOne = GetAllAvailableAppointmentByRoomAndDateTime(roomOneId, start, end);
            List<AppointmentRenovation> AppointmentRenovationsForRoomTwo = GetAllAvailableAppointmentByRoomAndDateTime(roomTwoId, start, end);
            List<AppointmentRenovation> AppointmentRenovations = new List<AppointmentRenovation>();
            foreach (AppointmentRenovation roomOne in AppointmentRenovationsForRoomOne)
            {
                var roomTwo = AppointmentRenovationsForRoomTwo.FirstOrDefault(r => r.Period.StartTime == roomOne.Period.StartTime);
                if (roomTwo != null) AppointmentRenovations.Add(roomTwo);
            }
            return AppointmentRenovations;
        }
    }
}
