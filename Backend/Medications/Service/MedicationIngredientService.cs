// File:    MedicationIngredientService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:56:43 PM
// Purpose: Definition of Class MedicationIngredientService

using Backend.Medications.Model;
using Backend.Medications.Repository.FileRepository;
using System;
using System.Collections.Generic;

namespace Backend.Medications.Service
{
   public class MedicationIngredientService
   {
        public MedicationIngredientService(IMedicationIngredientRepository medicationIngredientRepository)
        {
            this.medicationIngredientRepository = medicationIngredientRepository;
        }

        public MedicationIngredient AddIngredient(MedicationIngredient ingredient) =>
            medicationIngredientRepository.Create(ingredient);
        public IEnumerable<MedicationIngredient> GetAllIngredients() => 
            medicationIngredientRepository.GetAll();

        public IMedicationIngredientRepository medicationIngredientRepository;
   
   }
}