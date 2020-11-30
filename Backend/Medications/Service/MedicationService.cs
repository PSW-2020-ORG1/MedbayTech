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
        public IMedicationRepository _medicationRepository;
        public NotificationService notificationService;

        private MySqlContext _context;

        public MedicationService ( IMedicationRepository medicationRepository )
        {
            this._medicationRepository = medicationRepository;
        }

        public List<Medication> GetAllMedicationsByNameOrId ( string nameOfMedication )
        {
            List<Medication> medications = new List<Medication>();
            if ( Int32.TryParse(nameOfMedication, out int id) )
            {
                medications = _medicationRepository.GetAll().ToList().Where(p => p.Id == id).ToList();
                if ( medications.Count != 0 ) return medications;
            }
            medications = _medicationRepository.GetAll().ToList().Where(p => p.Med.ToLower().Contains(nameOfMedication.ToLower())).ToList();
            return medications;
        }

        public Medication RejectMedication ( Medication medication )
        {
            medication.Status = MedStatus.Approved;
            return _medicationRepository.Update(medication);
        }

        public Medication ApproveMedication ( Medication medication )
        {
            medication.Status = MedStatus.Rejected;
            return _medicationRepository.Update(medication);
        }

        public Medication CreateMedication ( Medication medication )
        {
            Medication fullMedication = medication;
            _medicationRepository.Create(medication);
            notificationService.MedForValidationNotification(medication);
            return medication;
        }

        public Medication UpdateMedication ( Medication medication ) =>
            _medicationRepository.Update(medication);

        public bool DeleteMedication ( Medication medication ) =>
            _medicationRepository.Delete(medication);

        public Medication GetMedication ( int id ) =>
            _medicationRepository.GetObject(id);

        public IEnumerable<Medication> GetAllOnValidationFor ( Doctor doctor )
        {
            List<Medication> allOnValidation = ( List<Medication> ) _medicationRepository.GetAllOnValidation().ToList();
            List<Medication> validations = new List<Medication>();
            foreach ( Medication medication in allOnValidation )
            {
                Specialization specialization = medication.MedicationCategory.Specialization;
                if ( doctor.IsMySpecialization(specialization) && medication.IsOnValidation() )

                    validations.Add((medication));
            }
            return validations;
        }

        public IEnumerable<Medication> GetAllOnValidation ( ) =>
            _medicationRepository.GetAllOnValidation();

        public IEnumerable<Medication> GetAll ( ) =>
            _medicationRepository.GetAll();

        public IEnumerable<Medication> GetAllRejected ( ) =>
            _medicationRepository.GetAllRejected();

        public IEnumerable<Medication> GetAllApproved ( ) =>
            _medicationRepository.GetAllApproved();

        public Medication AddAmount ( Medication medication, int amount )
        {
            medication.Quantity += amount;
            return _medicationRepository.Update(medication);
        }

        public Medication UpdateSideEffects ( Medication medication, SideEffect sideEffects )
        {
            medication.SideEffects.Add(sideEffects);
            return _medicationRepository.Update(medication);
        }

        public Medication UpdateDosageOfIngredients ( Medication medication, DosageOfIngredient dosageOfIngredient )
        {
            medication.MedicationContent.Add(dosageOfIngredient);
            return _medicationRepository.Update(medication);
        }

        public Medication UpdateAllergens ( Medication medication, Allergens allergens )
        {
            medication.Allergens.Add(allergens);
            return _medicationRepository.Update(medication);
        }
    }
}