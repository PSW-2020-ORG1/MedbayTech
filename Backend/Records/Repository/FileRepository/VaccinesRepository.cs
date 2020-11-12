// File:    VaccinesRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:38:47 AM
// Purpose: Definition of Class VaccinesRepository

using Backend.Records.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;

namespace Repository.MedicalRecordRepository
{
   public class VaccinesRepository : IVaccinesRepository
   {
        public Stream<Vaccines> stream;

        private const string ALREADY_EXISTS = "Vaccine already exists!";
        public VaccinesRepository(Stream<Vaccines> stream)
        {
            this.stream = stream;
        }

        public Vaccines Create(Vaccines entity)
        {
            if (!ExistsInSystem(entity)) 
            {
                List<Vaccines> allVaccines = (List<Vaccines>)stream.GetAll();
                allVaccines.Add(entity);
                stream.SaveAll(allVaccines);
                return entity;
            } else
            {
                throw new EntityAlreadyExists(ALREADY_EXISTS);
            }
        }

        public IEnumerable<Vaccines> GetAll() => stream.GetAll();

        public bool ExistsInSystem(Vaccines vaccines)
        {
            var allVaccines = stream.GetAll().ToList();
            return allVaccines.Any(item => item.Name == vaccines.Name);
        }
    }
}