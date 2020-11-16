/***********************************************************************
 * Module:  MedicationService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicationService
 ***********************************************************************/

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Medications.Repository.FileRepository;
using Model.Users;
using Service.GeneralService;

namespace Backend.Medications.Service
{
   public class MedicationService
   {
        public IMedicationRepository medicationRepository;
        public NotificationService notificationService;
        public IValidationMedicationRepository validationMedicationRepository;

        public MedicationService(IMedicationRepository medicationRepository, IValidationMedicationRepository validationMedicationRepository)
        {
            this.validationMedicationRepository = validationMedicationRepository;
            this.medicationRepository = medicationRepository;
        }

        public Medication RejectMedication(Medication medication)
        {
            medication.Status = MedStatus.Approved;
            return medicationRepository.Update(medication);
        }

        public Medication ApproveMedication(Medication medication)
        {
            medication.Status = MedStatus.Rejected;
            return medicationRepository.Update(medication);
        }

        public Medication CreateMedication(Medication medication)
        {
            Medication fullMedication = medication;
            medicationRepository.Create(medication);
            notificationService.MedForValidationNotification(medication);
            return medication;
        }

        public Medication UpdateMedication(Medication medication) => 
            medicationRepository.Update(medication);

        public bool DeleteMedication(Medication medication) => 
            medicationRepository.Delete(medication);

        public Medication GetMedication(int id) => 
            medicationRepository.GetObject(id);
      
        public IEnumerable<Medication> GetAllOnValidationFor(Doctor doctor)
        {
            List<Medication> allOnValidation = (List<Medication>) medicationRepository.GetAllOnValidation().ToList();
            List<Medication> validations = new List<Medication>();
            foreach (Medication medication in allOnValidation)
            {
                Specialization specialization = medication.MedicationCategory.Specialization;
                if (doctor.IsMySpecialization(specialization) && medication.IsOnValidation())
                
                    validations.Add((medication));
            }
            return validations;
        }
       
        public IEnumerable<Medication> GetAllOnValidation() => 
            medicationRepository.GetAllOnValidation();

        public IEnumerable<Medication> GetAll() => 
            medicationRepository.GetAll();

        public IEnumerable<Medication> GetAllRejected() => 
            medicationRepository.GetAllRejected();

        public IEnumerable<Medication> GetAllApproved() => 
            medicationRepository.GetAllApproved();

        public Medication AddAmount(Medication medication, int amount)
        {
            medication.Quantity += amount;
            return medicationRepository.Update(medication);
        }

        public Medication UpdateSideEffects(Medication medication, SideEffect sideEffects)
        {
            medication.SideEffects.Add(sideEffects);
            return medicationRepository.Update(medication);
        }

        public Medication UpdateDosageOfIngredients(Medication medication, DosageOfIngredient dosageOfIngredient)
        {
            medication.MedicationContent.Add(dosageOfIngredient);
            return medicationRepository.Update(medication);
        }

        public Medication UpdateAllergens(Medication medication, Allergens allergens)
        {
            medication.Allergens.Add(allergens);
            return medicationRepository.Update(medication);
        }



    }
}