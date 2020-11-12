/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Model.Rooms;
using Service.RoomService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.RoomController
{
   public class HospitalEquipmentController
   {
       
        public HospitalEquipmentController(HospitalEquipmentService hospitalEquipmentService)
        {
            this.hospitalEquipmentService = hospitalEquipmentService;
        }
        public HospitalEquipment AddEquipment(HospitalEquipment equipment) => hospitalEquipmentService.AddEquipment(equipment);
        public bool DeleteEquipment(HospitalEquipment hospitalEquipment) => hospitalEquipmentService.DeleteEquipment(hospitalEquipment);
        public IEnumerable<HospitalEquipment> GetEquipmentByRoomNumber(int roomNumber) => hospitalEquipmentService.GetEquipmentByRoomNumber(roomNumber);
        public HospitalEquipment UpdateAmountOfEquipment(HospitalEquipment equipment, int amount) => hospitalEquipmentService.UpdateAmountOfEquipment(equipment, amount);

        public HospitalEquipment UpdateHospitalEquipment(HospitalEquipment equipment) => hospitalEquipmentService.UpdateEquipment(equipment);

        public HospitalEquipment GetHospitalEquipment(int id) => hospitalEquipmentService.GetHospitalEquipment(id);
        public IEnumerable<HospitalEquipment> GetAllEquipment() => hospitalEquipmentService.GetAllEquipment();

        public HospitalEquipmentService hospitalEquipmentService;



    }
}