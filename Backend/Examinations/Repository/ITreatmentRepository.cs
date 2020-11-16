// File:    ITreatmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:08:25 AM
// Purpose: Definition of Interface ITreatmentRepository

using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using Repository;

namespace Backend.Examinations.Repository
{
   public interface ITreatmentRepository : IRepository<Treatment, int>
   {
        IEnumerable<Prescription> GetAllPrescriptionsInPeriod(DateTime startDate, DateTime endDate);
        IEnumerable<Prescription> GetAllPrescriptions();
        IEnumerable<HospitalTreatment> GetAllHospitalTreatments();
    }
}