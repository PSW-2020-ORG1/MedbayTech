// File:    ITreatmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:08:25 AM
// Purpose: Definition of Interface ITreatmentRepository

using Model.ExaminationSurgery;
using System;
using System.Collections.Generic;

namespace Repository.ExaminationRepository
{
   public interface ITreatmentRepository : IRepository<Treatment, int>
   {
      IEnumerable<Prescription> GetAllPrescriptionsInPeriodOfTime(DateTime startDate, DateTime endDate);
      
      IEnumerable<Prescription> GetAllPrescriptions();
      
      IEnumerable<HospitalTreatment> GetAllHospitalTreatments();
   
   }
}