/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Backend.Rooms.Service;
using Model;
using Model.Rooms;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.RoomService
{
    public class HospitalEquipmentService : IHospitalEquipmentService
    {
        private MySqlContext _context;

        public HospitalEquipmentService ( MySqlContext context )
        {
            _context = context;
        }

        public HospitalEquipmentService ( IHospitalEquipmentRepository hospitalEquipmentRepository )
        {
            this._hospitalEquipmentRepository = hospitalEquipmentRepository;
        }

        public List<HospitalEquipment> GetHospitalEquipmentsByNameOrId ( string textBoxSearch )
        {
            List<HospitalEquipment> hospitalEquipment = new List<HospitalEquipment>();
            if ( Int32.TryParse(textBoxSearch, out int id) )
            {
                hospitalEquipment = _hospitalEquipmentRepository.GetAll().ToList().Where(p => p.Id == id).ToList();
                if ( hospitalEquipment.Count != 0 ) return hospitalEquipment;
            }
            hospitalEquipment = _hospitalEquipmentRepository.GetAll().ToList().Where(p => p.EquipmentType.Name.ToLower().Trim().Contains(textBoxSearch.ToLower())).ToList();

            return hospitalEquipment;
        }

        public HospitalEquipment AddEquipment ( HospitalEquipment equipment ) => _hospitalEquipmentRepository.Create(equipment);

        public HospitalEquipment UpdateEquipment ( HospitalEquipment equipment ) => _hospitalEquipmentRepository.Update(equipment);

        public bool DeleteEquipment ( HospitalEquipment equipment ) => _hospitalEquipmentRepository.Delete(equipment);

        public IEnumerable<HospitalEquipment> GetEquipmentByRoomNumber ( int id ) => _hospitalEquipmentRepository.GetEquipmentByRoomNumber(id);

        public HospitalEquipment GetHospitalEquipment ( int id ) => _hospitalEquipmentRepository.GetObject(id);

        public HospitalEquipment UpdateAmountOfEquipment ( HospitalEquipment equipment, int amount )
        {
            equipment.QuantityInStorage += amount;
            _hospitalEquipmentRepository.Update(equipment);
            return equipment;
        }

        public IEnumerable<HospitalEquipment> GetAllEquipment ( ) => _hospitalEquipmentRepository.GetAll();

        public IHospitalEquipmentRepository _hospitalEquipmentRepository;
    }
}