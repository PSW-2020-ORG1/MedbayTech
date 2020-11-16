/***********************************************************************
 * Module:  MedicationValidationSevice.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicationValidationSevice
 ***********************************************************************/

using Backend.Medications.Model;
using Backend.Medications.Repository.FileRepository;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Medications.Service
{
   public class ValidationMedicationService
   {
        public ValidationMedicationService(IValidationMedicationRepository validationMedicationRepository, NotificationService notificationService)
        {
            this.validationMedicationRepository = validationMedicationRepository;
            this.notificationService = notificationService;
        }

        public ValidationMed ReviewValidation(ValidationMed validation)
        {
            ValidationMed validationToUpdate = validationMedicationRepository.GetObject(validation.Id);
            validationToUpdate.Reviewed = true;
            return validationMedicationRepository.Update(validation);
        }

        public ValidationMed AddValidation(ValidationMed medication)
        {
            ValidationMed fullValidation = medication;
            validationMedicationRepository.Create(medication);
            notificationService.MedicationValidatedNotification(fullValidation.Doctor);
            return medication;
        }
        public ValidationMed UpdateValidationMedication(ValidationMed medication) => 
            validationMedicationRepository.Update(medication);

        public IEnumerable<ValidationMed> GetAllUnreviewed() => 
            validationMedicationRepository.GetAllUnreviewed();

        public bool DeleteValidationMedication(ValidationMed medication) => 
            validationMedicationRepository.Delete(medication);

        public IValidationMedicationRepository validationMedicationRepository;
        public NotificationService notificationService;
   
   }
}