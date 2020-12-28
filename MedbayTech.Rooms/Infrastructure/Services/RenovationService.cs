// File:    RenovationService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:03:50 PM
// Purpose: Definition of Class RenovationService


using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Application.Common.Interfaces.Service;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Rooms.Application.Common.Service
{
    public class RenovationService : IRenovationService
    {
        public int allowedRenovationPeriod;
        public int validStartDate;

        public IRenovationRepository _renovationRepository;
        public IAppointmentRepository _appointmentRepository;
        public IHospitalEquipmentService _hospitalEquipmentService;
        public IRoomService _roomService;
        public INotificationService _notificationService;
        private const string HAS_APPOINTMENTS = "Can't schedule renovation for room {0} because it has appointments in the future";

        public List<Renovation> GetAllRenovations() => _renovationRepository.GetAll();
        public RenovationService(IRenovationRepository renovationRepository, RoomService roomService,
            IAppointmentRepository appointmentRepository,
            HospitalEquipmentService hospitalEquipmentService,
            NotificationService notificationService, int allowedRenovationPeriod, int validStartDate)
        {
            this._appointmentRepository = appointmentRepository;
            this.allowedRenovationPeriod = allowedRenovationPeriod;
            this.validStartDate = validStartDate;
            this._hospitalEquipmentService = hospitalEquipmentService;
            this._notificationService = notificationService;
            this._renovationRepository = renovationRepository;
            this._roomService = roomService;
        }

        public Renovation GetRenovation(int id) => _renovationRepository.GetBy(id);
        public void MoveAllToStorage(Renovation renovation)
        {
            Room roomToUpdate = _roomService.GetRoom(renovation.Room.Id);
            var storages = _roomService.GetAllRoomsFromOneType(RoomType.StorageRoom).ToList();
            foreach (HospitalEquipment equipment in _hospitalEquipmentService.GetEquipmentByRoomNumber(roomToUpdate.Id))
            {
                _hospitalEquipmentService.UpdateEquipment(equipment);
            }
        }

        public Renovation CreateNewRenovation(Renovation renovation)
        {
            if (CheckIfHasNewAppointments(renovation))
            {
                _renovationRepository.Create(renovation);
                _notificationService.RenovationNotification();
                if (renovation.MoveEquipment)
                    MoveAllToStorage(renovation);
                return renovation;
            }
            return null;
        }

        
        public Renovation EditRenovation(Renovation renovation)
        {
            _renovationRepository.Update(renovation);
            if (renovation.MoveEquipment)
                MoveAllToStorage(renovation);
            return renovation;
        }
        public bool DeleteRenovation(Renovation renovation) => _renovationRepository.Delete(renovation);

        public List<Renovation> GetRenovationsFromOneRoom(int roomNumber)
        {
            var allRenovations = _renovationRepository.GetAll();
            List<Renovation> renovationsFromOneRoom = new List<Renovation>();

            foreach (Renovation renovation in allRenovations)
            {
                if (renovation.Room.RoomNumber == roomNumber)
                {
                    renovationsFromOneRoom.Add(renovation);
                }
            }
            return renovationsFromOneRoom;
        }

        public List<Renovation> GetActiveRenovations()
        {
            var allRenovations = _renovationRepository.GetAll();
            List<Renovation> activeRenovations = new List<Renovation>();
            foreach (Renovation renovation in allRenovations)
            {
                if (renovation.Period.StartTime.CompareTo(DateTime.Today) < 0)
                {
                    activeRenovations.Add(renovation);
                }
            }
            return activeRenovations;

        }

        public bool IsStartDateValid(DateTime date)
        {
            DateTime validDate = DateTime.Today.AddDays((0 - validStartDate));
            return validDate.CompareTo(date) == 1;
        }

        public bool CheckIfHasNewAppointments(Renovation renovation)
        {
            /*  var allAppointments = appointmentRepository.GetScheduledFromToday();
              if (allAppointments.Any(ent => ent.Value.Room.Id == renovation.Room.Id)
                  && allAppointments.Any(ent2 => ent2.Value.Period.StartTime.Date.CompareTo(renovation.Period.StartTime.Date) >= 0 
                  && allAppointments.Any(ent1 => ent1.Value.Period.StartTime.Date.CompareTo(renovation.Period.EndTime.Date) <= 0)))
                  throw new RoomHasAppointments(string.Format(HAS_APPOINTMENTS, renovation.Room.Id));
              return true;*/
            throw new NotImplementedException();
        }
    } 
}