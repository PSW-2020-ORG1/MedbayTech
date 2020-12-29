// File:    IMedicalRecordRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:36:46 AM
// Purpose: Definition of Interface IMedicalRecordRepository

using System.Collections.Generic;
using MedbayTech.Common.Repository;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;

namespace Repository.MedicalRecordRepository
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, int> 
   {
        List<MedicalRecord> GetRecordsFor(string doctorId);
        MedicalRecord GetRecordBy(string patientId);

    }
}