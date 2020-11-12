// File:    IDiagnosisRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:36:48 AM
// Purpose: Definition of Interface IDiagnosisRepository

using Backend.Records.Model;
using System;

namespace Repository.MedicalRecordRepository
{
    public interface IDiagnosisRepository : IRepository<Diagnosis, int>
    {
        Diagnosis GetBy(string name);
        Diagnosis UpdateSymptoms(Diagnosis diagnosis, Symptoms symptom);
    }
}