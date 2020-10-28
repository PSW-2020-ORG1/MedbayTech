// File:    DiagnosisService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:46:13 PM
// Purpose: Definition of Class DiagnosisService

using Model.MedicalRecord;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.MedicalRecordService
{
   public class DiagnosisService
   {
        public DiagnosisService(IDiagnosisRepository diagnosisRepository)
        {
            this.diagnosisRepository = diagnosisRepository;
        }

        public Diagnosis AddDiagnosis(Diagnosis diagnosis) => diagnosisRepository.Create(diagnosis);
        public Diagnosis UpdateDiagnosis(Diagnosis diagnosis) => diagnosisRepository.Update(diagnosis);

        public bool DeleteDiagnosis(Diagnosis diagnosis) => diagnosisRepository.Delete(diagnosis);

        public Diagnosis AddSymptom(Diagnosis diagnosis, Symptoms symptom)
        {
            Diagnosis diagnosisToUpdate = diagnosisRepository.GetObject(diagnosis.Code);
            diagnosisToUpdate.Symptoms.Add(symptom);
            return diagnosisRepository.Update(diagnosisToUpdate);
        }

        public Diagnosis GetDiagnosis(int id) => diagnosisRepository.GetObject(id);

        public IEnumerable<Diagnosis> GetAllDiagnosis() => diagnosisRepository.GetAll();
      
        public IEnumerable<Diagnosis> GetAllDiagnosisBySymptoms(IEnumerable<Symptoms> symptoms)
        {
            List<Diagnosis> diagnosisBySymptoms = new List<Diagnosis>();
            var allDiagnosis = diagnosisRepository.GetAll().ToList();
            foreach (Diagnosis diagnosis in allDiagnosis)
            {
                foreach(Symptoms symptom in symptoms)
                {
                    if (diagnosis.Symptoms.Any(entity => entity.Name.Equals(symptom.Name)))
                    {
                        diagnosisBySymptoms.Add(diagnosis);
                        break;
                    }
                }
            }
            return diagnosisBySymptoms;
        }

        public Diagnosis FindByName(string name) => diagnosisRepository.GetByName(name);

        public IDiagnosisRepository diagnosisRepository;
   
   }
}