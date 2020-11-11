// File:    IMedicationIngredientRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:36 AM
// Purpose: Definition of Interface IMedicationIngredientRepository

using Model.Medications;
using System;

namespace Repository.MedicationRepository
{
   public interface IMedicationIngredientRepository : ICreate<MedicationIngredient>, IGetAll<MedicationIngredient>
   {
   }
}