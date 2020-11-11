/***********************************************************************
 * Module:  MedicationService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.MedicationService
 ***********************************************************************/

using Model.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository.MedicationRepository;
using Model.Users;

namespace Service.MedicationService
{
   public class MedicationService
   {
        public IMedicationRepository medicationRepository;
        public GeneralService.NotificationService notificationService;
        public IValidationMedicationRepository validationMedicationRepository;

        public MedicationService(IMedicationRepository medicationRepository, IValidationMedicationRepository validationMedicationRepository)
        {
            this.validationMedicationRepository = validationMedicationRepository;
            this.medicationRepository = medicationRepository;
        }
      
        public Medication RejectMedication(Medication medication)
        {
            medication.Status = MedStatus.Rejected;
            return medicationRepository.Update(medication);
        }
      
        public Medication ApproveMedication(Medication medication)
        {
            medication.Status = MedStatus.Approved;
            return medicationRepository.Update(medication);
        }

        public Medication CreateMedication(Medication medication)
        {
            Medication fullMedication = medication;
            medicationRepository.Create(medication);
            Specialization specialization = fullMedication.MedicationCategory[0].Specialization;
            notificationService.MedForValidationNotification(specialization);
            return medication;
        }
        public Medication UpdateMedication(Medication medication) => medicationRepository.Update(medication);

        public bool DeleteMedication(Medication medication) => medicationRepository.Delete(medication);

        public Medication GetMedication(int id) => medicationRepository.GetObject(id);
      
        public IEnumerable<Medication> GetAllOnValidationForDoctor(Doctor doctor)
        {
            var allOnValidation = medicationRepository.GetAllOnValidation().ToList();
            List<Medication> validations = new List<Medication>();
            foreach (Medication medication in allOnValidation)
            {
                foreach (MedicationCategory medicationCategory in medication.MedicationCategory)
                {
                    foreach (Specialization specialization in doctor.Specializations)
                    {
                        if (specialization.SpecializationName.Equals(medicationCategory.Specialization.SpecializationName))
                        {
                            validations.Add(medication);
                        }
                    }
                }
            }
            CheckIfAlreadyValidated(validations, doctor);
            return validations;
        }

        public void CheckIfAlreadyValidated(List<Medication> validations, Doctor doctor)
        {
            foreach (ValidationMed validation in validationMedicationRepository.GetAll())
            {
                for (int i = 0; i < validations.Count; i++)
                {
                    Medication medication = validations[i];
                    if (medication.Id == validation.Medication.Id && doctor.Username.Equals(validation.Doctor.Username))
                    {
                        validations.Remove(medication);
                    }
                }
            }
        }
        public IEnumerable<Medication> GetAllOnValidation() => medicationRepository.GetAllOnValidation();
        public IEnumerable<Medication> GetAll() => medicationRepository.GetAll();
        public IEnumerable<Medication> GetAllRejectedMeds() => medicationRepository.GetAllRejected();
        public IEnumerable<Medication> GetAllApprovedMeds() => medicationRepository.GetAllApproved();
        public Medication AddAmount(Medication medication, int amount)
        {
            medication.Quantity += amount;
            medicationRepository.Update(medication);
            return medication;
        }
      
        

    }
}