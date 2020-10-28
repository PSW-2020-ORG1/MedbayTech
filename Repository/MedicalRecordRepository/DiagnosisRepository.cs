// File:    DiagnosisRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:38:49 AM
// Purpose: Definition of Class DiagnosisRepository

using Model.MedicalRecord;
using Repository.ReportRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;
using SimsProjekat.Repository;

namespace Repository.MedicalRecordRepository
{
   public class DiagnosisRepository :  JSONRepository<Diagnosis, int>,
        IDiagnosisRepository
   {
        public DiagnosisRepository(Stream<Diagnosis> stream) : base(stream, "Diagnosis") { }

        public new Diagnosis Create(Diagnosis entity)
        {
            entity.Code = GetNextID();
            return base.Create(entity);
        }

        public Diagnosis GetByName(string name) => base.GetAll().ToList().SingleOrDefault(entity => entity.Name.Equals(name));
        public int GetNextID() => stream.GetAll().ToList().Count + 1;
    }
}