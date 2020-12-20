using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Rooms.Service
{
    public interface IRoomService
    {
        Room GetRoomByRoomNumber(int roomNumber);
        List<Room> GetRoomsByRoomLabelorRoomUse(string textBoxSearch);
        Room GetRoomById(int roomId);
        Room UpdateRoomDataBase(Room room);
        Room UpdateRoom(Room room);
        Room AddRoomToDepartment(Room room, Department department);
        Room AddRoom(Room room);
        Room GetRoom(int id);
        Room ChangeRoomType(Room room, RoomType type);
        bool DeleteRoom(Room room);
        List<Room> GetAllRoomsFromOneType(RoomType type);
        List<Room> GetAllRoomsFromOneDepartment(Department department);
        Room AddHospitalEquipmentToRoom(Room room, HospitalEquipment hospitalEquipment);
        Room UpdateDepartment(Department department, Room room);
        List<Room> GetAll();
    }
}
