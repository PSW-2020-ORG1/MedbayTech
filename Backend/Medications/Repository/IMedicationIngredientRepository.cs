// File:    IMedicationIngredientRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:36 AM
// Purpose: Definition of Interface IMedicationIngredientRepository

using Backend.Medications.Model;
using System;
using Repository;

namespace Backend.Medications.Repository.FileRepository
{
   public interface IMedicationIngredientRepository : ICreate<MedicationIngredient>, IGetAll<MedicationIngredient>
   {
   }
}