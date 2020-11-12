/***********************************************************************
 * Module:  ValidationMedRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.ValidationMedRepository
 ***********************************************************************/

using Backend.Medications.Model;
using Model.Users;
using Repository.UserRepository;
using Backend.General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Backend.Medications.Repository.FileRepository
{
   public class ValidationMedicationRepository :JSONRepository<ValidationMed, int>,
        IValidationMedicationRepository, ObjectComplete<ValidationMed>
    {
        public IMedicationRepository medicationRepository;
        public IUserRepository userRepository;
        
        public ValidationMedicationRepository(Stream<ValidationMed> stream, IUserRepository userRepository, MedicationRepository medicationRepository) : base(stream, "Validation")
        {
            this.userRepository = userRepository;
            this.medicationRepository = medicationRepository;
        }

        public new ValidationMed Create(ValidationMed entity)
        {
            entity.Id = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public IEnumerable<ValidationMed> GetAll()
        {
            var validations = stream.GetAll();
            BindWithMedication(validations);
            return validations;
        }

        public IEnumerable<ValidationMed> GetAllUnreviewed()
        {

            var validations = stream.GetAll().Where(validation => validation.Reviewed == false).ToList();
            BindWithMedication(validations);
            return validations;
        }

        public new ValidationMed GetObject(int id)
        {
            var validation = base.GetObject(id);
            CompleteObject(validation);
            return validation;
        }


        public new ValidationMed Update(ValidationMed entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }


        public int GetNextID() => 
            stream.GetAll().ToList().Count + 1;


        public void SetMissingValues(ValidationMed entity)
        {
            int MedId = entity.Medication.Id;
            entity.Medication = new Medication(MedId);
            entity.Doctor = new Doctor();
        }

        public void CompleteObject(ValidationMed validation)
        {
            validation.Medication = medicationRepository.GetObject(validation.Medication.Id);
            validation.Doctor = (Doctor)userRepository.GetObject(validation.Doctor.Username);
        }

        public void BindWithMedication(IEnumerable<ValidationMed> validations)
        {
            foreach (ValidationMed validation in validations)
            {
                validation.Medication = medicationRepository.GetObject(validation.Medication.Id);
                validation.Doctor = (Doctor)userRepository.GetObject(validation.Doctor.Username);
            }
        }

    }
}