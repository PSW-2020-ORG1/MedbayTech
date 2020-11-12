// File:    IValidationMedicationRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:34 AM
// Purpose: Definition of Interface IValidationMedicationRepository

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using Repository;

namespace Backend.Medications.Repository.FileRepository
{
   public interface IValidationMedicationRepository : IRepository<ValidationMed,int>
   {
        IEnumerable<ValidationMed> GetAllUnreviewed();
    }
}