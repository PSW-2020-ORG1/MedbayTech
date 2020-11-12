// File:    AllergensService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:44:37 PM
// Purpose: Definition of Class AllergensService

using Backend.Medications.Model;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;

namespace Service.MedicalRecordService
{
   public class AllergensService
   {
        public AllergensService(IAllergensRepository allergensRepository)
        {
            this.allergensRepository = allergensRepository;
        }

        public IEnumerable<Allergens> GetAllAllergies() => 
            allergensRepository.GetAll();

        public Allergens CreateAllergen(Allergens allergens) => 
            allergensRepository.Create(allergens);

      
        public IAllergensRepository allergensRepository;
   
   }
}