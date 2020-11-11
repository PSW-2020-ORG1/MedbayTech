// File:    IVaccinesRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:36:47 AM
// Purpose: Definition of Interface IVaccinesRepository

using Model.MedicalRecord;
using System;

namespace Repository.MedicalRecordRepository
{
   public interface IVaccinesRepository : IGetAll<Vaccines>, ICreate<Vaccines>
   {
   }
}