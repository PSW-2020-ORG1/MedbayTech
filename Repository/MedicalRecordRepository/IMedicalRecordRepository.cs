// File:    IMedicalRecordRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:36:46 AM
// Purpose: Definition of Interface IMedicalRecordRepository

using Model.MedicalRecord;
using System;
using System.Collections.Generic;

namespace Repository.MedicalRecordRepository
{
   public interface IMedicalRecordRepository : IRepository<MedicalRecord,int>
   {
      IEnumerable<MedicalRecord> GetRecordsForDoctor(Model.Users.Doctor doctor);
      
      IEnumerable<MedicalRecord> FilterRecordsByState(Model.MedicalRecord.PatientCondition state);
      
      Model.MedicalRecord.MedicalRecord GetRecordByPatient(Model.Users.Patient patient);
   
   }
}