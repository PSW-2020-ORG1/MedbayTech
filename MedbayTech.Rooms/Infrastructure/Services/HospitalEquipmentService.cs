/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/


using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Application.Common.Service;
using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Rooms.Infrastructure.Services
{
    public class HospitalEquipmentService : IHospitalEquipmentService
    {
        public IHospitalEquipmentRepository _hospitalEquipmentRepository;

        public HospitalEquipmentService ( IHospitalEquipmentRepository hospitalEquipmentRepository )
        {
            _hospitalEquipmentRepository = hospitalEquipmentRepository;
        }

        public List<HospitalEquipment> GetHospitalEquipmentsByNameOrId ( string textBoxSearch )
        {
            if (Int32.TryParse(textBoxSearch, out int id))
            {
                return _hospitalEquipmentRepository.GetAll().ToList().Where(med => med.Id == id).ToList();
            }
            else
            {
                return _hospitalEquipmentRepository.GetAll().ToList().Where(med => med.EquipmentType.Name.ToLower().Contains(textBoxSearch.ToLower())).ToList();
            }
        }

        public HospitalEquipment AddEquipment ( HospitalEquipment equipment ) => _hospitalEquipmentRepository.Create(equipment);

        public HospitalEquipment UpdateEquipment ( HospitalEquipment equipment ) => _hospitalEquipmentRepository.Update(equipment);

        public bool DeleteEquipment ( HospitalEquipment equipment ) => _hospitalEquipmentRepository.Delete(equipment);

        public List<HospitalEquipment> GetEquipmentByRoomNumber ( int id ) => _hospitalEquipmentRepository.GetEquipmentByRoomNumber(id);

        public HospitalEquipment GetHospitalEquipment ( int id ) => _hospitalEquipmentRepository.GetBy(id);

        public HospitalEquipment UpdateAmountOfEquipment ( HospitalEquipment equipment, int amount )
        {
            equipment.QuantityInStorage += amount;
            _hospitalEquipmentRepository.Update(equipment);
            return equipment;
        }

        public List<HospitalEquipment> GetAllEquipment ( ) => _hospitalEquipmentRepository.GetAll();

    }
}