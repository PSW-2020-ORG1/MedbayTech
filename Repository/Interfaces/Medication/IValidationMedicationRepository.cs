// File:    IValidationMedicationRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:34 AM
// Purpose: Definition of Interface IValidationMedicationRepository

using Model.Medications;
using System;
using System.Collections.Generic;

namespace Repository.MedicationRepository
{
   public interface IValidationMedicationRepository : IRepository<ValidationMed,int>
   {
      IEnumerable<ValidationMed> GetAllUnreviewed();
   
   }
}