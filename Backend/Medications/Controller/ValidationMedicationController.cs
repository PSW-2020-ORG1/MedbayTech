// File:    ValidationMedicationController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:45:02 AM
// Purpose: Definition of Class ValidationMedicationController

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using Backend.Medications.Service;

namespace Backend.Medications.Controller
{
   public class ValidationMedicationController
   {
        
        public ValidationMedicationController(ValidationMedicationService validationMedicationService)
        {
            this.validationMedicationService = validationMedicationService;
        }

        public ValidationMed ReviewValidation(ValidationMed validation) => 
            validationMedicationService.ReviewValidation(validation);
        public ValidationMed AddValidation(ValidationMed medication) => 
            validationMedicationService.AddValidation(medication);
        public ValidationMed UpdateValidation(ValidationMed medication) => 
            validationMedicationService.UpdateValidationMedication(medication);
        public IEnumerable<ValidationMed> GetAllUnreviewed() => 
            validationMedicationService.GetAllUnreviewed();
        public bool DeleteValidation(ValidationMed medication) => 
            validationMedicationService.DeleteValidationMedication(medication);

        public ValidationMedicationService validationMedicationService;
   
   }
}