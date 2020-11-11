// File:    LabTestTypeRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:29:27 AM
// Purpose: Definition of Class LabTestTypeRepository

using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using SimsProjekat.SIMS.Exceptions;

namespace Backend.Examinations.Repository
{
   public class LabTestTypeRepository : ILabTestTypeRepository
   {
        public Stream<LabTestType> stream;

        private const string ALREADY_EXISTS = "Lab test already exists!";

        public LabTestTypeRepository(Stream<LabTestType> stream)
        {
            this.stream = stream;
        }

        public LabTestType Create(LabTestType entity)
        {
            if (!ExistsInSystem(entity))
            {
                var allTypes = stream.GetAll().ToList();
                allTypes.Add(entity);
                stream.SaveAll(allTypes);
                return entity;
            }
            throw new EntityAlreadyExists(ALREADY_EXISTS);
            
        }

        public IEnumerable<LabTestType> GetAll() => stream.GetAll();
        public bool ExistsInSystem(LabTestType symptoms)
        {
            var allTypes = stream.GetAll().ToList();
            return allTypes.Any(item => item.TestName == symptoms.TestName);
        }
    }
}