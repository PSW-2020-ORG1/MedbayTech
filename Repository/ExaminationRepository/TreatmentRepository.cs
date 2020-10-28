// File:    TreatmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:29:28 AM
// Purpose: Definition of Class TreatmentRepository

using Model.ExaminationSurgery;
using Model.Users;
using Repository.ReportRepository;
using System;
using System.Collections.Generic;
using Repository.MedicationRepository;
using Repository.RoomRepository;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;
using Model.Medications;
using Model.Rooms;
using SimsProjekat.Repository;

namespace Repository.ExaminationRepository
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
            entity.Id = GetNextID();
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
                if (treatment.Type == TreatmentType.hospitalTreatment)
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
                if (treatment.Type == TreatmentType.prescription)
                {
                    CompleteObject(treatment);
                    treatments.Add((Prescription)treatment);
                }
            }
            return treatments;
        }

        public IEnumerable<Prescription> GetAllPrescriptionsInPeriodOfTime(DateTime startDate, DateTime endDate)
        {
            var allPrescriptions = GetAllPrescriptions();
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription prescription in allPrescriptions)
            {
                if (prescription.Date.CompareTo(startDate) > 0 && 
                    prescription.Date.CompareTo(endDate) < 0)
                {
                    prescriptions.Add(prescription);
                }
            }
            return prescriptions;
        }

        public int GetNextID() => stream.GetAll().ToList().Count + 1;

        public void SetMissingValues(Treatment entity)
        {
            if (entity.Type == TreatmentType.prescription)
            {
                SetPrescription(entity);
            }
            else if (entity.Type == TreatmentType.hospitalTreatment)
            {
                SetHospitalTreatment(entity);
            }
        }

        public void SetPrescription(Treatment entity)
        {
            Prescription prescription = (Prescription)entity;
            for (int i = 0; i < prescription.Medications.Count; i++)
            {
                prescription.Medications[i] = new Medication(prescription.Medications[i].MedId);
            }
        }

        public void SetHospitalTreatment(Treatment entity)
        {
            HospitalTreatment treatment = (HospitalTreatment)entity;
            treatment.Department = new Department(treatment.Department.Id);
        }

        public void CompleteObject(Treatment entity)
        {
            if (entity.Type == TreatmentType.hospitalTreatment)
            {
                CompleteHospitalTreatment(entity);
            }
            else if (entity.Type == TreatmentType.prescription)
            {
                CompletePrescription(entity);
            }
        }

        private void CompletePrescription(Treatment entity)
        {
            Prescription treatment = (Prescription)entity;
            for (int i = 0; i < treatment.Medications.Count; i++)
            {
                treatment.Medications[i] = medicationRepository.GetObject(treatment.Medications[i].MedId);
            }
        }

        private void CompleteHospitalTreatment(Treatment entity)
        {
            HospitalTreatment treatment = (HospitalTreatment)entity;
            treatment.Department = departmentRepository.GetObject(treatment.Department.DepartmentID);
        }
    }
}