// File:    IMedicalRecordRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:36:46 AM
// Purpose: Definition of Interface IMedicalRecordRepository


using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Domain.Enums;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Application.Common.Interfaces
{
   public interface IMedicalRecordRepository : IRepository<MedicalRecord,int> 
   {
        List<MedicalRecord> GetRecordsFor(Doctor doctor);

        List<MedicalRecord> FilterRecordsByState(PatientCondition state);

        MedicalRecord GetRecordBy(Patient patient);

        MedicalRecord GetMedicalRecordByPatientId(string id);
    }
}