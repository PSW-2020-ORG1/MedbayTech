// File:    ExaminationSurgeryRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:29:27 AM
// Purpose: Definition of Class ExaminationSurgeryRepository

using Model.ExaminationSurgery;
using Model.MedicalRecord;
using Repository.UserRepository;
using Repository.MedicalRecordRepository;
using Model.Users;
using Repository.ReportRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;
using SimsProjekat.Repository;

namespace Repository.ExaminationRepository
{
   public class ExaminationSurgeryRepository : JSONRepository<ExaminationSurgery, int>,
        IExaminationSurgeryRepository, ObjectComplete<ExaminationSurgery>
    {
        public ITreatmentRepository treatmentRepository;
        public IMedicalRecordRepository medicalRecordRepository;
        public IUserRepository doctorRepository;

        private const string NOT_FOUND = "Examination with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Examination with ID number {0} already exists!";


        public ExaminationSurgeryRepository(ITreatmentRepository treatmentRepository, 
            MedicalRecordRepository.IMedicalRecordRepository medicalRecordRepository, 
            UserRepository.UserRepository doctorRepository, Stream<ExaminationSurgery> stream) : base(stream, "Examination")
        {
            this.treatmentRepository = treatmentRepository;
            this.medicalRecordRepository = medicalRecordRepository;
            this.doctorRepository = doctorRepository;
        }

        public new ExaminationSurgery Create(ExaminationSurgery entity)
        {
            entity.IdNumber = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public int GetNextID() => stream.GetAll().ToList().Count + 1;
        public new IEnumerable<ExaminationSurgery> GetAll()
        {
            var examinations = base.GetAll();
            foreach (ExaminationSurgery examination in examinations)
            {
                CompleteObject(examination);
            }

            return examinations;
        }

        public IEnumerable<ExaminationSurgery> GetAllByDoctor(Doctor doctor)
        {
            var allExaminations = stream.GetAll().Where(item => item.Doctor.Id.Equals(doctor.Id)).ToList();
            foreach(ExaminationSurgery examintion in allExaminations)
            {
                CompleteObject(examintion);
            }
            return allExaminations;
        }
        public IEnumerable<ExaminationSurgery> GetAllByRecord(MedicalRecord record) => stream.GetAll().Where(item => item.MedicalRecord.IdRecord.Equals(record.IdRecord)).ToList();
 
        public new ExaminationSurgery GetObject(int id)
        {
            var examination = base.GetObject(id);
            CompleteDoctor(examination);
            return examination;
        }


        public new ExaminationSurgery Update(ExaminationSurgery entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }


        public void SetMissingValues(ExaminationSurgery entity)
        {
            SetMedicalRecord(entity);
            SetTreatmentIDs(entity);
            SetDoctor(entity);
        }

        private void SetDoctor(ExaminationSurgery entity)
        {
            entity.Doctor = new Doctor(entity.Doctor.Username);
        }

        private void SetMedicalRecord(ExaminationSurgery entity)
        {
            entity.MedicalRecord = new MedicalRecord(entity.MedicalRecord.IdRecord);
        }

        private void SetTreatmentIDs(ExaminationSurgery entity)
        {
            for (int i = 0; i < entity.Treatments.Count; i++)
            {
                if (entity.Treatments[i].Type == TreatmentType.hospitalTreatment)
                {
                    entity.Treatments[i] = new HospitalTreatment(entity.Treatments[i].Id);
                }
                else if (entity.Treatments[i].Type == TreatmentType.prescription)
                {
                    entity.Treatments[i] = new Prescription(entity.Treatments[i].Id);
                }
                else if (entity.Treatments[i].Type == TreatmentType.labTestType)
                {
                    entity.Treatments[i] = new LabTesting(entity.Treatments[i].Id);
                }
            }
        }

        public void CompleteObject(ExaminationSurgery examination)
        {
            CompleteTreatments(examination);
            CompleteMedicalRecord(examination);
            CompleteDoctor(examination);
        }

        private void CompleteDoctor(ExaminationSurgery examination)
        {
            examination.Doctor = (Doctor)doctorRepository.GetObject(examination.Doctor.Username);
        }

        private void CompleteMedicalRecord(ExaminationSurgery examination)
        {
            examination.MedicalRecord = medicalRecordRepository.GetObject(examination.MedicalRecord.IdRecord);
        }

        private void CompleteTreatments(ExaminationSurgery examination)
        {
            for (int i = 0; i < examination.Treatments.Count; i++)
            {
                examination.Treatments[i] = treatmentRepository.GetObject(examination.Treatments[i].Id);
            }
        }
    }
}