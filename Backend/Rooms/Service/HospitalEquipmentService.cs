/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Model;
using Model.Rooms;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.RoomService
{
   public class HospitalEquipmentService
   {

        private MySqlContext _context;

        public HospitalEquipmentService(MySqlContext context)
        {
            _context = context;
        }

        public HospitalEquipmentService(IHospitalEquipmentRepository hospitalEquipmentRepository)
        {
            this.hospitalEquipmentRepository = hospitalEquipmentRepository;
        }

        public List<HospitalEquipment> GetHospitalEquipmentsByName(string equipmentName)
        {
            return _context.HospitalEquipment.ToList().Where(p => p.EquipmentType.Name.ToLower().Trim().Contains(equipmentName)).ToList();
        }

        public List<HospitalEquipment> GetHospitalEquipmentsById(int equipmentId)
        {
            return _context.HospitalEquipment.ToList().Where(p => p.Id == equipmentId).ToList();
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