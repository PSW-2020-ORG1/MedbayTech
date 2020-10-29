// File:    IMedicationCategoryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:35 AM
// Purpose: Definition of Interface IMedicationCategoryRepository

using Model.Medications;
using System;

namespace Repository.MedicationRepository
{
   public interface IMedicationCategoryRepository : ICreate<MedicationCategory>, IGetAll<MedicationCategory>
   {
   }
}