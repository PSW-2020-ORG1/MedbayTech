/***********************************************************************
 * Module:  MedicationIngredient.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.MedicationIngredient
 ***********************************************************************/

using Model.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;

namespace Repository.MedicationRepository
{
   public class MedicationIngredientRepository : IMedicationIngredientRepository
   {
        public Stream<MedicationIngredient> stream;
        private const string ALREADY_EXISTS = "Ingredient already exists!";


        public MedicationIngredientRepository(Stream<MedicationIngredient> stream)
        {
            this.stream = stream;
        }

        public MedicationIngredient Create(MedicationIngredient entity)
        {
            if (!ExistsInSystem(entity))
            {
                var allIngredients = stream.GetAll().ToList();
                allIngredients.Add(entity);
                stream.SaveAll(allIngredients);
                return entity;
            } else
            {
                throw new EntityAlreadyExists(ALREADY_EXISTS);
            }
        }

        public IEnumerable<MedicationIngredient> GetAll() => stream.GetAll();
    
        public bool ExistsInSystem(MedicationIngredient ingredient)
        {
            var allIngredients = stream.GetAll().ToList();
            return allIngredients.Any(item => item.Name == ingredient.Name);
        }
    }
}