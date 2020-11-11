/***********************************************************************
 * Module:  SymptomsService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicalRecordService.SymptomsService
 ***********************************************************************/

using Model.MedicalRecord;
using Repository.MedicationRepository;
using System;
using System.Collections.Generic;

namespace Service.MedicationService
{
   public class SymptomsService
   {
        public SymptomsService(ISymptomsRepository symptomsRepository)
        {
            this.symptomsRepository = symptomsRepository;
        }

        public Symptoms AddSymptom(Symptoms symptom) => symptomsRepository.Create(symptom);

        public IEnumerable<Symptoms> GetAllSymptoms() => symptomsRepository.GetAll();

      
        public ISymptomsRepository symptomsRepository;
   
   }
}