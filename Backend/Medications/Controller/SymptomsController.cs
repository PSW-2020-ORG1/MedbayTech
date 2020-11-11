// File:    SymptomsController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:45:03 AM
// Purpose: Definition of Class SymptomsController

using Model.MedicalRecord;
using System;
using System.Collections.Generic;
using Service.MedicationService;

namespace Controller.MedicationController
{
   public class SymptomsController
   {

        public SymptomsController(SymptomsService symptomsService)
        {
            this.symptomsService = symptomsService;
        }
        public Symptoms AddSymptom(Symptoms symptom) => symptomsService.AddSymptom(symptom);    
        public IEnumerable<Symptoms> GetAllSymptoms() => symptomsService.GetAllSymptoms();

        public SymptomsService symptomsService;
   
   }
}