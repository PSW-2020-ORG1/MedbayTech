/***********************************************************************
 * Module:  HospitalEquipmentRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.HospitalEquipmentRepository
 ***********************************************************************/

using Model.Rooms;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.RoomRepository
{
   public class HospitalEquipmentRepository : JSONRepository<HospitalEquipment, int>,
        IHospitalEquipmentRepository
   {
       // public Stream<HospitalEquipment> stream;

        private const string NOT_FOUND = "Hospital equipment with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Hospital equipment with ID number {0} already exists!";

        public HospitalEquipmentRepository(Stream<HospitalEquipment> stream) :base(stream, "Hospital equipment")
        {
        }
        public new HospitalEquipment Create(HospitalEquipment entity)
        {
            entity.Id = GetNextID();
            return base.Create(entity);
        }
        public int GetNextID() => stream.GetAll().ToList().Count + 1;
        
        public IEnumerable<HospitalEquipment> GetEquipmentByRoomNumber(int id) => base.GetAll().Where(hospitalEquipment => hospitalEquipment.Id == id);
  
        public IEnumerable<HospitalEquipment> GetEquipmentByType(EquipmentType type) => base.GetAll().Where(hospitalEquipment => hospitalEquipment.EquipmentType.Name.Equals(type.Name));
        
    }
}