// File:    DiagnosisController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:50:32 AM
// Purpose: Definition of Class DiagnosisController

using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.MedicalRecordController
{
   public class DiagnosisController
   {
        public DiagnosisController(DiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
        }

        public Diagnosis AddDiagnosis(Diagnosis diagnosis) => 
            diagnosisService.AddDiagnosis(diagnosis);

        public Diagnosis UpdateDiagnosis(Diagnosis diagnosis) => 
            diagnosisService.UpdateDiagnosis(diagnosis);

        public bool DeleteDiagnosis(Diagnosis diagnosis) => 
            diagnosisService.DeleteDiagnosis(diagnosis);

        public Diagnosis GetDiagnosis(int id) => 
            diagnosisService.GetDiagnosis(id);

        public Diagnosis AddSymptom(Diagnosis diagnosis, Symptoms symptom) => 
            diagnosisService.AddSymptom(diagnosis, symptom);

        public IEnumerable<Diagnosis> GetAllDiagnosis() => 
            diagnosisService.GetAllDiagnosis();

        public IEnumerable<Diagnosis> GetAllDiagnosisBySymptoms(IEnumerable<Symptoms> symptoms) => 
            diagnosisService.GetAllDiagnosisBy(symptoms);

        public Diagnosis FindByName(string name) => 
            diagnosisService.GetBy(name);

        public Diagnosis UpdateSymptoms(Diagnosis diagnosis, Symptoms symptom) =>
            diagnosisService.UpdateSymptoms(diagnosis, symptom);

        public DiagnosisService diagnosisService;
   
   }
}