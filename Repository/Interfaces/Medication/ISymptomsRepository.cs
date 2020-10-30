// File:    ISymptomsRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:37 AM
// Purpose: Definition of Interface ISymptomsRepository

using Model.MedicalRecord;
using System;

namespace Repository.MedicationRepository
{
   public interface ISymptomsRepository : ICreate<Symptoms>, IGetAll<Symptoms>
   {
   }
}