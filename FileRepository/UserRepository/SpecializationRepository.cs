/***********************************************************************
 * Module:  SpecializationRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.SpecializationRepository
 ***********************************************************************/

using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.UserRepository
{
   public class SpecializationRepository : ISpecializationRepository
   {
        public Stream<Specialization> stream;

        private const string GENERAL_DOCTOR = "opšta praksa";

        public SpecializationRepository(Stream<Specialization> stream)
        {
            this.stream = stream;
        }

        public Specialization Create(Specialization entity)
        {
            var allSpecializations = stream.GetAll().ToList();
            allSpecializations.Add(entity);
            stream.SaveAll(allSpecializations);
            return entity;
        }

        public bool Delete(Specialization entity)
        {
            var allSpecializations = stream.GetAll().ToList();
            allSpecializations.Remove(entity);
            stream.SaveAll(allSpecializations);
            return true;
        }

        public IEnumerable<Specialization> GetAll() => stream.GetAll();
        public bool ExistsInSystem(Specialization specialization)
        {
            var allSpecializations = stream.GetAll().ToList();
            return allSpecializations.Any(item => item.SpecializationName.Equals(specialization.SpecializationName));
        }

        public Specialization GetGeneralSpecialization()
        {
            return stream.GetAll().SingleOrDefault(entity => entity.SpecializationName.Equals(GENERAL_DOCTOR));
        }
    }
}