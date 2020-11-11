// File:    IMedicationRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:36 AM
// Purpose: Definition of Interface IMedicationRepository

using Model.Medications;
using System;
using System.Collections.Generic;

namespace Repository.MedicationRepository
{
   public interface IMedicationRepository : IRepository<Medication, int>
   {
        IEnumerable<Medication> GetAllOnValidation();
      
        IEnumerable<Medication> GetAllRejected();
      
        IEnumerable<Medication> GetAllApproved();

        bool ExistsInSystem(int id);
        int GetNextID();


    }
}