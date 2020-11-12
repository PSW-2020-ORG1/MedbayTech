// File:    DiagnosisRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:38:49 AM
// Purpose: Definition of Class DiagnosisRepository

using Backend.Records.Model;
using System;
using System.Linq;
using Backend.General.Model;

namespace Repository.MedicalRecordRepository
{
   public class DiagnosisRepository :  JSONRepository<Diagnosis, int>,
        IDiagnosisRepository
   {
        public DiagnosisRepository(Stream<Diagnosis> stream) : base(stream, "Diagnosis") { }

        public new Diagnosis Create(Diagnosis entity)
        {
            entity.Id = GetNextID();
            return base.Create(entity);
        }

        public Diagnosis GetBy(string name) => base.GetAll().ToList().SingleOrDefault(entity => entity.Name.Equals(name));
        public int GetNextID() => stream.GetAll().ToList().Count + 1;

        public Diagnosis UpdateSymptoms(Diagnosis diagnosis, Symptoms symptom)
        {
            throw new NotImplementedException();
        }
    }
}