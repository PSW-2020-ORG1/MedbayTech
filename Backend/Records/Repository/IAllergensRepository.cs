// File:    IAllergensRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:36:48 AM
// Purpose: Definition of Interface IAllergensRepository

using Backend.Medications.Model;
using System;

namespace Repository.MedicalRecordRepository
{
   public interface IAllergensRepository : ICreate<Allergens>, IGetAll<Allergens>
   {
   }
}