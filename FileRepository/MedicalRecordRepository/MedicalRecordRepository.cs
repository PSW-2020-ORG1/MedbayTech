// File:    MedicalRecordRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:38:47 AM
// Purpose: Definition of Class MedicalRecordRepository

using Model.MedicalRecord;
using Model.Users;
using Repository.ReportRepository;
using System;
using System.Collections.Generic;
using Repository.MedicationRepository;
using Repository.UserRepository;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;
using Model.Medications;
using SimsProjekat.Repository;
using SimsProjekat.Exceptions;

namespace Repository.MedicalRecordRepository
{
   public class MedicalRecordRepository : JSONRepository<MedicalRecord, int>,
        IMedicalRecordRepository, ObjectComplete<MedicalRecord>
    {
        public IDiagnosisRepository illnessesRepository;
        public IMedicationRepository therapyRepository;
        public IUserRepository patientRepository;


        public MedicalRecordRepository(Stream<MedicalRecord> stream, IDiagnosisRepository diagnosisRepository, IMedicationRepository medicationRepository, IUserRepository userRepository) :
            base(stream, "Medical record")
        {
            illnessesRepository = diagnosisRepository;
            therapyRepository = medicationRepository;
            patientRepository = userRepository;
        }

        public new MedicalRecord Create(MedicalRecord entity)
        {
            entity.IdRecord = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public int GetNextID() => stream.GetAll().ToList().Count + 1;

        public IEnumerable<MedicalRecord> FilterRecordsByState(PatientCondition state)
        {
            var allRecordsByState = stream.GetAll().Where(item => item.CurrHealthState == state).ToList();
            foreach(MedicalRecord record in allRecordsByState)
            {
                CompleteObject(record);
            }

            return allRecordsByState;
        }
        public new IEnumerable<MedicalRecord> GetAll()
        {
            var records = base.GetAll();
            foreach (MedicalRecord medicalRecord in records)
            {
                CompleteObject(medicalRecord);
            }
            return records;
        }
        public new MedicalRecord GetObject(int id)
        {
            var record = base.GetObject(id);
            CompleteObject(record);
            return record;
        }

        public MedicalRecord GetRecordByPatient(Patient patient)
        {
            var record = stream.GetAll().SingleOrDefault(entity => entity.Patient.Username.CompareTo(patient.Username) == 0);
            if (record != null)
                CompleteObject(record);
            else
                throw new NoMedicalRecord();
            return record;
        }
        public IEnumerable<MedicalRecord> GetRecordsForDoctor(Doctor doctor)
        {
            var allWithChosenDoctor = GetAll().Where(entity => entity.Patient.ChosenDoctor != null);
            return allWithChosenDoctor.Where(entity => entity.Patient.ChosenDoctor.Username.Equals(doctor.Username));
        }

        public new MedicalRecord Update(MedicalRecord entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public void SetMissingValues(MedicalRecord entity)
        {
            SetPatient(entity);
            SetTherapies(entity);
            SetHistory(entity);
        }

        private void SetHistory(MedicalRecord entity)
        {
            SetFamilyIllnessHistory(entity);
            SetIllnessHistory(entity);
        }

        private void SetIllnessHistory(MedicalRecord entity)
        {
            for (int i = 0; i < entity.IllnessHistory.Count; i++)
            {
                entity.IllnessHistory[i] = new Diagnosis(entity.IllnessHistory[i].Code);
            }
        }

        private void SetFamilyIllnessHistory(MedicalRecord entity)
        {
            for (int i = 0; i < entity.FamilyIllnessHistory.Count; i++)
            {
                for (int j = 0; j < entity.FamilyIllnessHistory[i].Diagnosis.Count; j++)
                {
                    entity.FamilyIllnessHistory[i].Diagnosis[j] = new Diagnosis(entity.FamilyIllnessHistory[i].Diagnosis[j].Code);
                }
            }
        }

        private void SetTherapies(MedicalRecord entity)
        {
            for (int i = 0; i < entity.Therapies.Count; i++)
            {
                entity.Therapies[i].Medication = new Medication(entity.Therapies[i].Medication.MedId);
            }
        }

        private void SetPatient(MedicalRecord entity)
        {
            entity.Patient = new Patient(entity.Patient.Username);
        }

        public void CompleteObject(MedicalRecord record)
        {
            CompletePatient(record);
            CompleteHistory(record);
            CompleteTherapies(record);
        }

        private void CompleteTherapies(MedicalRecord entity)
        {
            for (int i = 0; i < entity.Therapies.Count; i++)
            {
                entity.Therapies[i].Medication = therapyRepository.GetObject(entity.Therapies[i].Medication.MedId);
            }
        }

        private void CompleteHistory(MedicalRecord entity)
        {
            CompleteFamilyIllnessHistory(entity);
            CompleteIllnessHistory(entity);
        }

        private void CompleteIllnessHistory(MedicalRecord entity)
        {
            for (int i = 0; i < entity.IllnessHistory.Count; i++)
            {
                entity.IllnessHistory[i] = illnessesRepository.GetObject(entity.IllnessHistory[i].Code);
            }
        }

        private void CompleteFamilyIllnessHistory(MedicalRecord entity)
        {
            for (int i = 0; i < entity.FamilyIllnessHistory.Count; i++)
            {
                for (int j = 0; j < entity.FamilyIllnessHistory[i].Diagnosis.Count; j++)
                {
                    entity.FamilyIllnessHistory[i].Diagnosis[j] = illnessesRepository.GetObject(entity.FamilyIllnessHistory[i].Diagnosis[j].Code);
                }
            }
        }

        private void CompletePatient(MedicalRecord entity)
        {
            entity.Patient = (Patient) patientRepository.GetObject(entity.Patient.Username);
        }
    }
}