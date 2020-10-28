// File:    RenovationService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:03:50 PM
// Purpose: Definition of Class RenovationService

using Model.Rooms;
using Repository.RoomRepository;
using Repository.ScheduleRepository;
using Service.GeneralService;
using System;
using System.Collections.Generic;
using System.Linq;
using SimsProjekat.Exceptions;

namespace Service.RoomService
{
   public class RenovationService
   {
        public int allowedRenovationPeriod;
        public int validStartDate;

        public IRenovationRepository renovationRepository;
        public IAppointmentRepository appointmentRepository;
        public HospitalEquipmentService hospitalEquipmentService;
        public RoomService roomService;
        public NotificationService notificationService;
        private const string HAS_APPOINTMENTS = "Can't schedule renovation for room {0} because it has appointments in the future";

        public IEnumerable<Renovation> GetAllRenovations() => renovationRepository.GetAll();
        public RenovationService(IRenovationRepository renovationRepository, RoomService roomService,
            IAppointmentRepository appointmentRepository,
            HospitalEquipmentService hospitalEquipmentService, 
            NotificationService notificationService, int allowedRenovationPeriod, int validStartDate)
        {
            this.appointmentRepository = appointmentRepository;
            this.allowedRenovationPeriod = allowedRenovationPeriod;
            this.validStartDate = validStartDate;
            this.hospitalEquipmentService = hospitalEquipmentService;
            this.notificationService = notificationService;
            this.renovationRepository = renovationRepository;
            this.roomService = roomService;
        }

        public Renovation GetRenovation(int id) => renovationRepository.GetObject(id);
        public void MoveAllToStorage(Renovation renovation)
        {
            Room roomToUpdate = roomService.GetRoom(renovation.Room.RoomID);
            var storages = roomService.GetAllRoomsFromOneType(RoomType.storage).ToList();
            foreach(HospitalEquipment equipment in hospitalEquipmentService.GetEquipmentByRoomNumber(roomToUpdate.RoomID))
            {
           //     equipment.Room = storages[0];
             //   equipment.RoomNumberIn = storages[0].RoomNumber;
                hospitalEquipmentService.UpdateEquipment(equipment);
            }
        }

        public Renovation CreateNewRenovation(Renovation renovation)
        {
            if (CheckIfHasNewAppointments(renovation))
            {
                renovationRepository.Create(renovation);
                notificationService.RenovationNotification();
                if (renovation.MoveEquipment)
                    MoveAllToStorage(renovation);
                return renovation;
            }
            return null;
        }

        private bool CheckIfHasNewAppointments(Renovation renovation)
        {
            var allAppointments = appointmentRepository.GetScheduledFromToday();
            if (allAppointments.Any(ent => ent.Value.Room.RoomID == renovation.Room.RoomID)
                && allAppointments.Any(ent2 => ent2.Value.StartTime.Date.CompareTo(renovation.StartDate.Date) >= 0 
                && allAppointments.Any(ent1 => ent1.Value.StartTime.Date.CompareTo(renovation.EndDate.Date) <= 0)))
                throw new RoomHasAppointments(string.Format(HAS_APPOINTMENTS, renovation.Room.RoomID));
            return true;
        }
        public Renovation EditRenovation(Renovation renovation)
        {
            renovationRepository.Update(renovation);
            if (renovation.MoveEquipment)
                MoveAllToStorage(renovation);
            return renovation;
        }
        public bool DeleteRenovation(Renovation renovation) => renovationRepository.Delete(renovation);
      
        public IEnumerable<Renovation> GetRenovationsFromOneRoom(int roomNumber)
        {
            var allRenovations = renovationRepository.GetAll();
            List<Renovation> renovationsFromOneRoom = new List<Renovation>();

            foreach(Renovation renovation in allRenovations)
            {
                if(renovation.Room.RoomNumber == roomNumber)
                {
                    renovationsFromOneRoom.Add(renovation);
                }
            }
            return renovationsFromOneRoom;
        }
      
        public IEnumerable<Renovation> GetActiveRenovations()
        {
            var allRenovations = renovationRepository.GetAll();
            List<Renovation> activeRenovations = new List<Renovation>();
            foreach(Renovation renovation in allRenovations)
            {
                if(renovation.StartDate.CompareTo(DateTime.Today) < 0)
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
      
      
   
   }
}