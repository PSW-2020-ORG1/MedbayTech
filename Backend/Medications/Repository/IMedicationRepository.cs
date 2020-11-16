// File:    IMedicationRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:40:36 AM
// Purpose: Definition of Interface IMedicationRepository

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using Repository;

namespace Backend.Medications.Repository.FileRepository
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