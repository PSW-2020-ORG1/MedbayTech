/***********************************************************************
 * Module:  MedicationCategoryRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.MedicationCategoryRepository
 ***********************************************************************/

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using SimsProjekat.SIMS.Exceptions;

namespace Backend.Medications.Repository.FileRepository
{
   public class MedicationCategoryRepository : IMedicationCategoryRepository
   {
        public Stream<MedicationCategory> stream;
        private const string ALREADY_EXISTS = "Category already exists!";

        public MedicationCategoryRepository(Stream<MedicationCategory> stream)
        {
            this.stream = stream;
        }

        public MedicationCategory Create(MedicationCategory entity)
        {
            if (!ExistsInSystem(entity))
            {
                var allCategories = stream.GetAll().ToList();
                allCategories.Add(entity);
                stream.SaveAll(allCategories);
                return entity;
            } else
            {

                throw new EntityAlreadyExists(ALREADY_EXISTS);
            }
        }

        public IEnumerable<MedicationCategory> GetAll() => stream.GetAll();

        public bool ExistsInSystem(MedicationCategory category)
        {
            var allCategories = stream.GetAll().ToList();
            return allCategories.Any(item => item.CategoryName == category.CategoryName);
        }
    }
}