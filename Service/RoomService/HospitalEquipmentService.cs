/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Model.Rooms;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;

namespace Service.RoomService
{
   public class HospitalEquipmentService
   {

        public HospitalEquipmentService(IHospitalEquipmentRepository hospitalEquipmentRepository)
        {
            this.hospitalEquipmentRepository = hospitalEquipmentRepository;
        }
        public HospitalEquipment AddEquipment(HospitalEquipment equipment) => hospitalEquipmentRepository.Create(equipment);
        public HospitalEquipment UpdateEquipment(HospitalEquipment equipment) => hospitalEquipmentRepository.Update(equipment);
        public bool DeleteEquipment(HospitalEquipment equipment) => hospitalEquipmentRepository.Delete(equipment);

       
        public IEnumerable<HospitalEquipment> GetEquipmentByRoomNumber(int id) => hospitalEquipmentRepository.GetEquipmentByRoomNumber(id);

        public HospitalEquipment GetHospitalEquipment(int id) => hospitalEquipmentRepository.GetObject(id);
        public HospitalEquipment UpdateAmountOfEquipment(HospitalEquipment equipment, int amount)
        {
            equipment.QuantityInStorage += amount;
            hospitalEquipmentRepository.Update(equipment);
            return equipment;
        }

        public IEnumerable<HospitalEquipment> GetAllEquipment() => hospitalEquipmentRepository.GetAll();

        public IHospitalEquipmentRepository hospitalEquipmentRepository;


    }
}