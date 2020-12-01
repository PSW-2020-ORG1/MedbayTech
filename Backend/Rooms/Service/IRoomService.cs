using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Rooms.Service
{
    public interface IRoomService
    {
        public Room GetRoomByRoomNumber(int roomNumber);
        public List<Room> GetRoomsByRoomLabelorRoomUse(string textBoxSearch);
        public Room GetRoomById(int roomId);
        public Room UpdateRoomDataBase(Room room);
        public Room UpdateRoom(Room room);
        public Room AddRoomToDepartment(Room room, Department department);
        public Room AddRoom(Room room);
        public Room GetRoom(int id);
        public Room ChangeRoomType(Room room, RoomType type);
        public bool DeleteRoom(Room room);
        public IEnumerable<Room> GetAllRoomsFromOneType(RoomType type);
        public IEnumerable<Room> GetAllRoomsFromOneDepartment(Department department);
        public Room AddHospitalEquipmentToRoom(Room room, HospitalEquipment hospitalEquipment);
        public Room UpdateDepartment(Department department, Room room);
        public List<Room> GetAll();
    }
}
