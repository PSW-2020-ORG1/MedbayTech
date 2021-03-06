// File:    RoomService.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 12:30:07 AM
// Purpose: Definition of Class RoomService


using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Application.Common.Service;
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Rooms.Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHospitalEquipmentRepository _hospitalEquipmentRepository;
        private const string APPOINTMENTS_SCHEDULED = "Room has appointments scheduled in future.";

        public RoomService ( IRoomRepository roomRepository, IHospitalEquipmentRepository hospitalEquipmentRepository )
        {
            _roomRepository = roomRepository;
            _hospitalEquipmentRepository = hospitalEquipmentRepository;
        }

        public List<Room> GetAllRooms ( ) => _roomRepository.GetAll().ToList();

        public Room GetRoomByRoomNumber ( int roomNumber )
        {
            var allRooms = _roomRepository.GetAll();
            foreach ( Room room in allRooms )
            {
                if ( room.RoomNumber.Equals(roomNumber) )
                {
                    return room;
                }
            }
            return null;
        }

        public List<Room> GetRoomsByRoomLabelorRoomUse(string textBoxSearch)
        {
            List<Room> rooms = new List<Room>();

            rooms = _roomRepository.GetAll().ToList().Where(p => p.RoomLabel.ToLower().Contains(textBoxSearch)).ToList();
            if (rooms.Count != 0)
            {
                return rooms;
            }

            rooms = _roomRepository.GetAll().ToList().Where(p => p.RoomUse.ToLower().Contains(textBoxSearch)).ToList();
            return rooms;
        }

        public Room GetRoomById(int id)
        {
            return _roomRepository.GetAll().ToList().Find(p => p.Id == id);
        }

        public Room UpdateRoomDataBase(Room room)
        {
            Room room_update = _roomRepository.GetAll().ToList().Find(r => r.Id == room.Id);
            room_update.UpdateRoom(room);
            _roomRepository.Update(room_update);
            return room;
        }

        public Room UpdateRoom ( Room room ) => _roomRepository.Update(room);

        public Room AddRoomToDepartment ( Room room, Department department )
        {
            var roomForChange = _roomRepository.GetBy(room.Id);
            roomForChange.Department = department;
            _roomRepository.Update(room);
            return room;
        }

        public Room AddRoom ( Room room ) => _roomRepository.Create(room);

        public Room GetRoom ( int id ) => _roomRepository.GetBy(id);

        public Room ChangeRoomType ( Room room, RoomType type )
        {
            var roomForChange = _roomRepository.GetBy(room.Id);
            roomForChange.RoomType = type;
            return _roomRepository.Update(roomForChange);
        }

        public bool DeleteRoom ( Room room )
        {
            /*var allAppointements = appointmentRepository.GetScheduledFromToday();
            if ( allAppointements.Any(ent => ent.Value.Room.Id == room.GetId()) )
                throw new RoomHasAppointmentsScheduled(APPOINTMENTS_SCHEDULED);
            return _roomRepository.Delete(room);*/
            return false;
        }

        public List<Room> GetAllRoomsFromOneType ( RoomType type )
        {
            var allRooms = _roomRepository.GetAll();
            List<Room> roomsOfOneType = new List<Room>();
            foreach ( Room room in allRooms )
            {
                if ( room.RoomType.Equals(type) )
                {
                    roomsOfOneType.Add(room);
                }
            }
            return roomsOfOneType.ToList();
        }

        public List<Room> GetAllRoomsFromOneDepartment ( Department department )
        {
            var allRooms = _roomRepository.GetAll();
            List<Room> roomsOfOneDepartment = new List<Room>();
            foreach ( Room room in allRooms )
            {
                if ( room.Department.Equals(department) )
                {
                    roomsOfOneDepartment.Add(room);
                }
            }
            return roomsOfOneDepartment.ToList();
        }

        public Room AddHospitalEquipmentToRoom ( Room room, HospitalEquipment hospitalEquipment )
        {
            var roomForChange = _roomRepository.GetBy(room.Id);
            roomForChange.HospitalEquipment.Add(hospitalEquipment);
            _roomRepository.Update(roomForChange);
            return room;
        }

        public Room UpdateDepartment ( Department department, Room room )
        {
            var roomToChange = _roomRepository.GetBy(room.Id);
            roomToChange.Department = department;
            return _roomRepository.Update(room);
        }

        public List<Room> GetAll ( )
        {
            return _roomRepository.GetAll().ToList();
        }


        public List<Room> GetAllRoomsByEquipment(int equipmentId)
        {
            List<Room> rooms = new List<Room>();
            foreach (Room room in GetAll())
            {
                var equipments = _hospitalEquipmentRepository.GetEquipmentByRoomNumber(room.Id);
                if (equipments.Any(e => e.EquipmentTypeId == equipmentId))
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public List<Room> GetNeighbouringRoom(int roomId)
        {
            List<Room> rooms = new List<Room>();
            Room room = _roomRepository.GetBy(roomId);
            List<Room> roomsRight = GetRoomByNumber(room.RoomNumber + 1);
            List<Room> roomsLeft = GetRoomByNumber(room.RoomNumber - 1);
            if(roomsRight != null)
            {
                foreach(Room roomTo in roomsRight)
                {
                    if (CompareTwoRooms(room, roomTo))
                    {
                        rooms.Add(roomTo);
                        break;
                    }
                }
                
            }
            if(roomsLeft != null)
            {
                foreach (Room roomTo in roomsLeft)
                {
                    if (CompareTwoRooms(room, roomTo))
                    {
                        rooms.Add(roomTo);
                        break;
                    }
                }
            }
            return rooms;
        }

        private List<Room> GetRoomByNumber(int roomNumber)
        {
            return _roomRepository.GetAll().ToList().Where(r => r.RoomNumber == roomNumber).ToList();
        }

        private bool CompareTwoRooms(Room room1, Room room2)
        {
            if (room1.DepartmentId != room2.DepartmentId) return false;
            if (room1.Department.HospitalId != room2.Department.HospitalId) return false;
            if (room1.Department.Floor != room2.Department.Floor) return false;
            return true;
        }
    }
}