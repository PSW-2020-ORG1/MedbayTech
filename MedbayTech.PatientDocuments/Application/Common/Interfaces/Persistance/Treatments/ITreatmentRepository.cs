// File:    ITreatmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:08:25 AM
// Purpose: Definition of Interface ITreatmentRepository

using System;
using System.Collections.Generic;
using MedbayTech.Common.Repository;
using Repository;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;

namespace Backend.Examinations.Repository
{
    public interface ITreatmentRepository : IRepository<Treatment, int>
   {
        List<Prescription> GetAllPrescriptionsInPeriod(DateTime startDate, DateTime endDate);
        List<Prescription> GetAllPrescriptions();
        List<HospitalTreatment> GetAllHospitalTreatments();
    }
}