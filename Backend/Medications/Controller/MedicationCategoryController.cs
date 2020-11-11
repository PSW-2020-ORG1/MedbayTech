// File:    MedicationCategoryController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:45:01 AM
// Purpose: Definition of Class MedicationCategoryController

using Model.Medications;
using System;
using System.Collections.Generic;
using Service.MedicationService;

namespace Controller.MedicationController
{
   public class MedicationCategoryController
   {

        public MedicationCategoryController(MedicationCategoryService medicationCategoryService)
        {
            this.medicationCategoryService = medicationCategoryService;
        }

        public MedicationCategory AddCategory(MedicationCategory category) => medicationCategoryService.AddCategory(category);
        public IEnumerable<MedicationCategory> GetAllCategories() => medicationCategoryService.GetAllCategories();
      
        public MedicationCategoryService medicationCategoryService;
   
   }
}