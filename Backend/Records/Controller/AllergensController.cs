// File:    AllergensController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:50:31 AM
// Purpose: Definition of Class AllergensController

using Backend.Medications.Model;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.MedicalRecordController
{
   public class AllergensController
   {
        public AllergensController(AllergensService allergensService)
        {
            this.allergensService = allergensService;
        }

        public IEnumerable<Allergens> GetAllAllergies() => 
            allergensService.GetAllAllergies();

        public Allergens CreateAllergen(Allergens allergens) => 
            allergensService.CreateAllergen(allergens);
        
        public AllergensService allergensService;
   
   }
}