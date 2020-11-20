// File:    IMedicationCategoryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:35 AM
// Purpose: Definition of Interface IMedicationCategoryRepository

using Backend.Medications.Model;
using System;
using Repository;

namespace Backend.Medications.Repository.FileRepository
{
   public interface IMedicationCategoryRepository : ICreate<MedicationCategory>, IGetAll<MedicationCategory>
   {
   }
}