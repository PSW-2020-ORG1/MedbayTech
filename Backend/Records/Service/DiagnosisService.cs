// File:    DiagnosisService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:46:13 PM
// Purpose: Definition of Class DiagnosisService

using Backend.Records.Model;
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

        public Diagnosis AddDiagnosis(Diagnosis diagnosis) => 
            diagnosisRepository.Create(diagnosis);

        public Diagnosis UpdateDiagnosis(Diagnosis diagnosis) => 
            diagnosisRepository.Update(diagnosis);

        public bool DeleteDiagnosis(Diagnosis diagnosis) => 
            diagnosisRepository.Delete(diagnosis);

        public Diagnosis AddSymptom(Diagnosis diagnosis, Symptoms symptom)
        {
            Diagnosis diagnosisToUpdate = diagnosisRepository.GetObject(diagnosis.Id);
            diagnosisToUpdate.Symptoms.Add(symptom);
            return diagnosisRepository.Update(diagnosisToUpdate);
        }

        public Diagnosis GetDiagnosis(int id) => 
            diagnosisRepository.GetObject(id);

        public IEnumerable<Diagnosis> GetAllDiagnosis() => 
            diagnosisRepository.GetAll();
      
        public IEnumerable<Diagnosis> GetAllDiagnosisBy(IEnumerable<Symptoms> symptoms)
        {
            List<Diagnosis> diagnosisBySymptoms = new List<Diagnosis>();
            List<Diagnosis> allDiagnosis = diagnosisRepository.GetAll().ToList();
            foreach (Diagnosis diagnosis in allDiagnosis)
                if (diagnosis.IsMySymptom(symptoms))
                    diagnosisBySymptoms.Add(diagnosis);

            return diagnosisBySymptoms;
        }

        public Diagnosis UpdateSymptoms(Diagnosis diagnosis, Symptoms symptom) =>
            diagnosisRepository.UpdateSymptoms(diagnosis, symptom);

        public Diagnosis GetBy(string name) => 
            diagnosisRepository.GetBy(name);

        public IDiagnosisRepository diagnosisRepository;
   
   }
}