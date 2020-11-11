// File:    RoomController.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:48:17 PM
// Purpose: Definition of Class RoomController

using Model.Rooms;
using Service.RoomService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.RoomController
{
   public class RoomController
   {
        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }
  
        public Room AddRoom(Room room) => roomService.AddRoom(room);
        public Room AddHospitalEquipmentToRoom(Room room, HospitalEquipment hospitalEquipment) => roomService.AddHospitalEquipmentToRoom(room, hospitalEquipment);
        public Room ChangeRoomType(Room room, RoomType type) => roomService.ChangeRoomType(room, type);
        public bool DeleteRoom(Room room) => roomService.DeleteRoom(room);
        public Room GetRoomByRoomNumber(int roomNumber) => roomService.GetRoomByRoomNumber(roomNumber);
        public Room UpdateRoom(Room room) => roomService.UpdateRoom(room);
        public Room AddRoomToDepartment(Room room, Department department) => roomService.AddRoomToDepartment(room, department);
        public Room GetRoom(int roomId) => roomService.GetRoom(roomId);
        public IEnumerable<Room> GetAllRoomsOfOneType(RoomType type) => roomService.GetAllRoomsFromOneType(type);
        public IEnumerable<Room> GetAllRoomsFromOneDepartment(Department department) => roomService.GetAllRoomsFromOneDepartment(department);
        public Room UpdateDepartment(Department department, Room room) => roomService.UpdateDepartment(department, room);
        public IEnumerable<Room> GetAllRooms() => roomService.GetAllRooms();

        public RoomService roomService;
    }
}