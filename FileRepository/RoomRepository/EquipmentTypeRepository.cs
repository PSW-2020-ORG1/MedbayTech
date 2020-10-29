// File:    EquipmentTypeRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 3:23:46 AM
// Purpose: Definition of Class EquipmentTypeRepository

using Model.Rooms;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.RoomRepository
{
   public class EquipmentTypeRepository : IEquipmentTypeRepository
   {
        public Stream<EquipmentType> stream;

        
        private const string ALREADY_EXISTS = "Equipment type with name {0} already exists!";

        public EquipmentTypeRepository(Stream<EquipmentType> stream)
        {
            this.stream = stream;
        }

        public EquipmentType Create(EquipmentType entity)
        {
            if (!ExistsInSystem(entity.Name))
            {
                var allEquipmentTypes = stream.GetAll().ToList();
                allEquipmentTypes.Add(entity);
                stream.SaveAll(allEquipmentTypes);
                return entity;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entity.Name));
            }
        }

        public IEnumerable<EquipmentType> GetAll() => stream.GetAll();

        public bool ExistsInSystem(string name)
        {
            var allEquipmentTypes = stream.GetAll().ToList();
            return allEquipmentTypes.Any(item => item.Name== name);
        }
    }
}