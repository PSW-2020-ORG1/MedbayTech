// File:    AllergensRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:38:50 AM
// Purpose: Definition of Class AllergensRepository

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;

namespace Repository.MedicalRecordRepository
{
   public class AllergensRepository : IAllergensRepository
   {
        public Stream<Allergens> stream;
        private const string ALREADY_EXISTS = "Allergen already exists!";

        public AllergensRepository(Stream<Allergens> stream)
        {
            this.stream = stream;
        }

        public Allergens Create(Allergens entity)
        {
            if (!ExistsInSystem(entity))
            {
                var allAllergens = stream.GetAll().ToList();
                allAllergens.Add(entity);
                stream.SaveAll(allAllergens);
                return entity;
            } else
            {
                throw new EntityAlreadyExists(ALREADY_EXISTS);
            }
        }

        public IEnumerable<Allergens> GetAll() => stream.GetAll();
        
        public bool ExistsInSystem(Allergens allergens)
        {
            var allAllergens = stream.GetAll().ToList();
            return allAllergens.Any(item => item.Allergen == allergens.Allergen);
        }
    }
}