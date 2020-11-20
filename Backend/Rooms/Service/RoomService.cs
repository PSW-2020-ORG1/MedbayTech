// File:    RoomService.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 12:30:07 AM
// Purpose: Definition of Class RoomService

using Model.Rooms;
using Repository.RoomRepository;
using Repository.ScheduleRepository;
using Backend.Exceptions.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.RoomService
{
   public class RoomService
   {
        public IEnumerable<Room> GetAllRooms() => roomRepository.GetAll();

        public IRoomRepository roomRepository;
        public IAppointmentRepository appointmentRepository;
        private const string APPOINTMENTS_SCHEDULED = "Room has appointments shceduled in future.";

        public RoomService(IRoomRepository roomRepository, IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.roomRepository = roomRepository;
        }

        public Room GetRoomByRoomNumber(int roomNumber)
        {
            var allRooms = roomRepository.GetAll();
            foreach (Room room in allRooms)
            {
                if (room.RoomNumber.Equals(roomNumber))
                {
                    return room;
                }
            }
            return null;
        }
        public Room UpdateRoom(Room room) => roomRepository.Update(room);
        public Room AddRoomToDepartment(Room room, Department department)
        {
            var roomForChange = roomRepository.GetObject(room.Id);
            roomForChange.Department = department;
            roomRepository.Update(room);
            return room;

        }

        public Room AddRoom(Room room) => roomRepository.Create(room);

        public Room GetRoom(int id) => roomRepository.GetObject(id);

        public Room ChangeRoomType(Room room, RoomType type)
        {
            var roomForChange = roomRepository.GetObject(room.Id);
            roomForChange.RoomType = type;
            return roomRepository.Update(roomForChange);
        }

        public bool DeleteRoom(Room room)
        {
            var allAppointements = appointmentRepository.GetScheduledFromToday();
            if (allAppointements.Any(ent => ent.Value.Room.Id == room.GetId()))
                throw new RoomHasAppointmentsScheduled(APPOINTMENTS_SCHEDULED);
            return roomRepository.Delete(room);
            }
        public IEnumerable<Room> GetAllRoomsFromOneType(RoomType type)
        {
            var allRooms = roomRepository.GetAll();
            List<Room> roomsOfOneType = new List<Room>();
            foreach(Room room in allRooms)
            {
                if(room.RoomType.Equals(type))
                {
                    roomsOfOneType.Add(room);
                }
            }
            return roomsOfOneType;
        }
      
        public IEnumerable<Room> GetAllRoomsFromOneDepartment(Department department)
        {
            var allRooms = roomRepository.GetAll();
            List<Room> roomsOfOneDepartment = new List<Room>();
            foreach (Room room in allRooms)
            {
                if (room.Department.Equals(department))
                {
                    roomsOfOneDepartment.Add(room);
                }
            }
            return roomsOfOneDepartment;
        }
        public Room AddHospitalEquipmentToRoom(Room room, HospitalEquipment hospitalEquipment)
        {
            var roomForChange = roomRepository.GetObject(room.Id);
            roomForChange.HospitalEquipment.Add(hospitalEquipment);
            roomRepository.Update(roomForChange);
            return room;

        }
        public Room UpdateDepartment(Department department, Room room)
        {
            var roomToChange = roomRepository.GetObject(room.Id);
            roomToChange.Department = department;
            return roomRepository.Update(room);

        }

    }
}