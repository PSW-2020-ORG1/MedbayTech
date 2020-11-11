// File:    ValidationMedicationController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:45:02 AM
// Purpose: Definition of Class ValidationMedicationController

using Model.Medications;
using System;
using System.Collections.Generic;
using Service.MedicationService;

namespace Controller.MedicationController
{
   public class ValidationMedicationController
   {
        
        public ValidationMedicationController(ValidationMedicationService validationMedicationService)
        {
            this.validationMedicationService = validationMedicationService;
        }

        public ValidationMed SetToReviewed(ValidationMed validation) => validationMedicationService.SetToReviewed(validation);
        public ValidationMed AddValidationMedication(ValidationMed medication) => validationMedicationService.AddValidationMedication(medication);
        public ValidationMed UpdateValidationMedication(ValidationMed medication) => validationMedicationService.UpdateValidationMedication(medication);
        public IEnumerable<ValidationMed> GetAllUnreviewed() => validationMedicationService.GetAllUnreviewed();
        public bool DeleteValidationMedication(ValidationMed medication) => validationMedicationService.DeleteValidationMedication(medication);

        public ValidationMedicationService validationMedicationService;
   
   }
}