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
using Model;

namespace Backend.Medications.Service
{
   public class MedicationService : IMedicationService
   {
        private INotificationService _notificationService;
        private IMedicationRepository _medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository, INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public List<Medication> GetAllMedicationsByNameOrId(string query)
        {
            if (Int32.TryParse(query, out int id))
                return _medicationRepository.GetAll().Where(med => med.Id == id).ToList();
            return _medicationRepository.GetAll().Where(med => med.Med.ToLower().Contains(query.ToLower())).ToList();

        }
   
        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public Medication UpdateMedicationDataBase(Medication medication)
        {
            _medicationRepository.Update(medication);
            return medication;
        }

        public List<Medication> GetAllMedicationByRoomId(string query)
        {
            if (Int32.TryParse(query, out int id))
            {
                return _medicationRepository.GetAll().ToList().Where(med => med.RoomId == id).ToList();
            }
            return new List<Medication>();
        }

        public Medication RejectMedication(Medication medication)
        {
            medication.Status = MedStatus.Approved;
            return _medicationRepository.Update(medication);
        }

        public Medication ApproveMedication(Medication medication)
        {
            medication.Status = MedStatus.Rejected;
            return _medicationRepository.Update(medication);
        }

        public Medication CreateMedication(Medication medication)
        {
            Medication fullMedication = medication;
            _medicationRepository.Create(medication);
            _notificationService.MedForValidationNotification(medication);

            return medication;
        }
        public Medication UpdateMedication(Medication medication) => 
            _medicationRepository.Update(medication);

        public bool DeleteMedication(Medication medication) => 
            _medicationRepository.Delete(medication);


        public Medication GetMedication(int id) =>
            _medicationRepository.GetObject(id);

       
        public IEnumerable<Medication> GetAllOnValidation() => 
            _medicationRepository.GetAllOnValidation();

        public IEnumerable<Medication> GetAll() => 
            _medicationRepository.GetAll();

        public IEnumerable<Medication> GetAllRejected() => 
            _medicationRepository.GetAllRejected();

        public IEnumerable<Medication> GetAllApproved() =>
            _medicationRepository.GetAllApproved();

        public Medication AddAmount(Medication medication, int amount)
        {
            medication.Quantity += amount;
            return _medicationRepository.Update(medication);
        }

        public Medication UpdateSideEffects(Medication medication, SideEffect sideEffects)
        {
            medication.SideEffects.Add(sideEffects);
            return _medicationRepository.Update(medication);
        }

        public Medication UpdateDosageOfIngredients(Medication medication, DosageOfIngredient dosageOfIngredient)
        {
            medication.MedicationContent.Add(dosageOfIngredient);
            return _medicationRepository.Update(medication);
        }

        public Medication UpdateAllergens(Medication medication, Allergens allergens)
        {
            medication.Allergens.Add(allergens);
            return _medicationRepository.Update(medication);
        }

        // NOTE(Jovan): For PHIntegration testing purposes
        public Medication Add(Medication medication) => _medicationRepository.Create(medication);
    }
}