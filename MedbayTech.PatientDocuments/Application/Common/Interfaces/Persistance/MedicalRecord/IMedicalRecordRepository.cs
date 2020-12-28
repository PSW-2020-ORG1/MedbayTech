// File:    IMedicalRecordRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:36:46 AM
// Purpose: Definition of Interface IMedicalRecordRepository

using Backend.Records.Model;
using Backend.Records.Model.Enums;
using System;
using System.Collections.Generic;
using MedbayTech.Common.Repository;

namespace Repository.MedicalRecordRepository
{
   public interface IMedicalRecordRepository : IRepository<MedicalRecord,int> 
   {
        List<MedicalRecord> GetRecordsFor(string doctorId);

        List<MedicalRecord> FilterRecordsByState(PatientCondition state);

        MedicalRecord GetRecordBy(string patientId);

    }
}