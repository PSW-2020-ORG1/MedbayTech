// File:    IMedicalRecordRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:36:46 AM
// Purpose: Definition of Interface IMedicalRecordRepository

using Backend.Records.Model;
using Backend.Records.Model.Enums;
using System;
using System.Collections.Generic;

namespace Repository.MedicalRecordRepository
{
   public interface IMedicalRecordRepository : IRepository<MedicalRecord,int> 
   {
        IEnumerable<MedicalRecord> GetRecordsFor(Model.Users.Doctor doctor);
      
        IEnumerable<MedicalRecord> FilterRecordsByState(PatientCondition state);

        MedicalRecord GetRecordBy(Model.Users.Patient patient);

        MedicalRecord GetMedicalRecordByPatientId(string id);
    }
}