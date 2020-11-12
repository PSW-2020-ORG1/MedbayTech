// File:    MedicationCategoryService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:56:43 PM
// Purpose: Definition of Class MedicationCategoryService

using Backend.Medications.Model;
using Backend.Medications.Repository.FileRepository;
using System;
using System.Collections.Generic;

namespace Backend.Medications.Service
{
   public class MedicationCategoryService
   {
        public MedicationCategoryService(IMedicationCategoryRepository medicationCategoryRepository)
        {
            this.medicationCategoryRepository = medicationCategoryRepository;
        }

        public MedicationCategory AddCategory(MedicationCategory category) => 
            medicationCategoryRepository.Create(category);

        public IEnumerable<MedicationCategory> GetAllCategories() => 
            medicationCategoryRepository.GetAll();

        public IMedicationCategoryRepository medicationCategoryRepository;
   
   }
}