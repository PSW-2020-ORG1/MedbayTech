// File:    MedicationIngredientController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:45:06 AM
// Purpose: Definition of Class MedicationIngredientController

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using Backend.Medications.Service;

namespace Backend.Medications.Controller
{
   public class MedicationIngredientController
   {
        public MedicationIngredientController(MedicationIngredientService medicationIngredientService)
        {
            this.medicationIngredientService = medicationIngredientService;
        }

        public MedicationIngredient AddIngredient(MedicationIngredient ingredient) => 
            medicationIngredientService.AddIngredient(ingredient);
        public IEnumerable<MedicationIngredient> GetAllIngredients() => 
            medicationIngredientService.GetAllIngredients();
      
        public MedicationIngredientService medicationIngredientService;
   
   }
}