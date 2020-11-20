// File:    MedicationCategoryController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:45:01 AM
// Purpose: Definition of Class MedicationCategoryController

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using Backend.Medications.Service;

namespace Backend.Medications.Controller
{
   public class MedicationCategoryController
   {

        public MedicationCategoryController(MedicationCategoryService medicationCategoryService)
        {
            this.medicationCategoryService = medicationCategoryService;
        }

        public MedicationCategory AddCategory(MedicationCategory category) => 
            medicationCategoryService.AddCategory(category);
        public IEnumerable<MedicationCategory> GetAllCategories() => 
            medicationCategoryService.GetAllCategories();
      
        public MedicationCategoryService medicationCategoryService;
   
   }
}