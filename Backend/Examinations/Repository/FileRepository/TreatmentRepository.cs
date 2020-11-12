// File:    TreatmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:29:28 AM
// Purpose: Definition of Class TreatmentRepository

using Backend.Examinations.Model;
using Model.Users;
using System;
using System.Collections.Generic;
using Backend.Medications.Repository.FileRepository;
using Repository.RoomRepository;
using System.Linq;
using Backend.Examinations.Model.Enums;
using Backend.Medications.Model;
using Model.Rooms;
using Repository;
using Backend.General.Model;

namespace Backend.Examinations.Repository
{
    public class TreatmentRepository : JSONRepository<Treatment, int>,
        ITreatmentRepository, ObjectComplete<Treatment>
    {

        public IMedicationRepository medicationRepository;
        public IDepartmentRepository departmentRepository;

        private const string NOT_FOUND = "Treatment with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Treatment with ID number {0} already exists!";

        public TreatmentRepository(IMedicationRepository medicationRepository, IDepartmentRepository departmentRepository, Stream<Treatment> stream) : base(stream, "Treatment")
        {
            this.departmentRepository = departmentRepository;
            this.medicationRepository = medicationRepository;
          
        }

        public new Treatment Create(Treatment entity)
        {
            entity.Id = GetNextId();
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public new Treatment Update(Treatment entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public new Treatment GetObject(int id)
        {
            var treatment = base.GetObject(id);
            CompleteObject(treatment);
            return treatment;
        }

        public new IEnumerable<Treatment> GetAll()
        {
            var allTreatment = base.GetAll();
            List<Treatment> treatments = new List<Treatment>();
            foreach(Treatment treatment in allTreatment)
            {
                CompleteObject(treatment);
                treatments.Add(treatment);
            }
            return treatments;
        } 

        public IEnumerable<HospitalTreatment> GetAllHospitalTreatments()
        {
            var allTreatment = base.GetAll();
            List<HospitalTreatment> treatments = new List<HospitalTreatment>();
            foreach (Treatment treatment in allTreatment)
            {
                if (treatment.Type == TreatmentType.HospitalTreatment)
                {
                    CompleteObject(treatment);
                    treatments.Add((HospitalTreatment)treatment);
                }
            }
            return treatments;
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {

            var allTreatment = base.GetAll();
            List<Prescription> treatments = new List<Prescription>();
            foreach (Treatment treatment in allTreatment)
            {
                if (treatment.Type == TreatmentType.Prescription)
                {
                    CompleteObject(treatment);
                    treatments.Add((Prescription)treatment);
                }
            }
            return treatments;
        }

        public IEnumerable<Prescription> GetAllPrescriptionsInPeriod(DateTime startDate, DateTime endDate)
        {
            List<Prescription> allPrescriptions = (List<Prescription>) GetAllPrescriptions();
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription prescription in allPrescriptions)
            {
                if (prescription.IsStillActive(startDate, endDate))
                {
                    prescriptions.Add(prescription);
                }
            }
            return prescriptions;
        }


        public int GetNextId() => stream.GetAll().ToList().Count + 1;

        public void SetMissingValues(Treatment entity)
        {
            if (entity.Type == TreatmentType.Prescription)
            {
                SetPrescription(entity);
            }
            else if (entity.Type == TreatmentType.HospitalTreatment)
            {
                SetHospitalTreatment(entity);
            }
        }

        public void SetPrescription(Treatment entity)
        {
            Prescription prescription = (Prescription)entity;
            prescription.Medication = medicationRepository.GetObject(prescription.Medication.Id);
        }

        public void SetHospitalTreatment(Treatment entity)
        {
            HospitalTreatment treatment = (HospitalTreatment)entity;
            treatment.Department = new Department();
        }

        public void CompleteObject(Treatment entity)
        {
            if (entity.Type == TreatmentType.HospitalTreatment)
            {
                CompleteHospitalTreatment(entity);
            }
            else if (entity.Type == TreatmentType.Prescription)
            {
                CompletePrescription(entity);
            }
        }

        private void CompletePrescription(Treatment entity)
        {
            Prescription treatment = (Prescription)entity;
            treatment.Medication = medicationRepository.GetObject(treatment.Medication.Id);
        }

        private void CompleteHospitalTreatment(Treatment entity)
        {
            HospitalTreatment treatment = (HospitalTreatment)entity;
            treatment.Department = departmentRepository.GetObject(treatment.Department.Id);
        }

    }
}