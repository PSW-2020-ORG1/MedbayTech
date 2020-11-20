/***********************************************************************
 * Module:  SymptomsService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicalRecordService.SymptomsService
 ***********************************************************************/

using Backend.Records.Model;
using Backend.Medications.Repository.FileRepository;
using System;
using System.Collections.Generic;

namespace Backend.Medications.Service
{
   public class SymptomsService
   {
        public SymptomsService(ISymptomsRepository symptomsRepository)
        {
            this.symptomsRepository = symptomsRepository;
        }

        public Symptoms AddSymptom(Symptoms symptom) => 
            symptomsRepository.Create(symptom);

        public IEnumerable<Symptoms> GetAllSymptoms() => 
            symptomsRepository.GetAll();

      
        public ISymptomsRepository symptomsRepository;
   
   }
}