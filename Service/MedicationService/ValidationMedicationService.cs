/***********************************************************************
 * Module:  MedicationValidationSevice.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicationValidationSevice
 ***********************************************************************/

using Model.Medications;
using Repository.MedicationRepository;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Service.MedicationService
{
   public class ValidationMedicationService
   {
        public ValidationMedicationService(IValidationMedicationRepository validationMedicationRepository, NotificationService notificationService)
        {
            this.validationMedicationRepository = validationMedicationRepository;
            this.notificationService = notificationService;
        }

        public ValidationMed SetToReviewed(ValidationMed validation)
        {
            ValidationMed validationToChange = validationMedicationRepository.GetObject(validation.Id);
            validationToChange.Reviewed = true;
            return validationMedicationRepository.Update(validationToChange);
        }

        public ValidationMed AddValidationMedication(ValidationMed medication)
        {
            ValidationMed fullValidation = medication;
            validationMedicationRepository.Create(medication);
            notificationService.MedicationValidatedNotification(fullValidation.Doctor);
            return medication;
        }
        public ValidationMed UpdateValidationMedication(ValidationMed medication) => validationMedicationRepository.Update(medication);

        public IEnumerable<ValidationMed> GetAllUnreviewed() => validationMedicationRepository.GetAllUnreviewed();

        public bool DeleteValidationMedication(ValidationMed medication) => validationMedicationRepository.Delete(medication);

        public IValidationMedicationRepository validationMedicationRepository;
        public NotificationService notificationService;
   
   }
}