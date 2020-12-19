// File:    TreatmentService.cs
// Author:  Vlajkov
// Created: Monday, June 01, 2020 10:34:45 PM
// Purpose: Definition of Class TreatmentService

using Backend.Examinations.Model;
using Model.Users;
using Backend.Examinations.Repository;
using Service.GeneralService;
using System;
using System.Collections.Generic;
using Backend.Examinations.Model.Enums;
using Backend.Users.Repository.MySqlRepository;
using Backend.Examinations.Service.Interfaces;
using Backend.Medications.Service;

namespace Backend.Examinations.Service
{
    public class TreatmentService : ITreatmentService
    {
        public INotificationService notificationService;
        public ITreatmentRepository treatmentRepository;

        public TreatmentService(ITreatmentRepository treatmentRepository, INotificationService notificationService)
        {
            this.notificationService = notificationService;
            this.treatmentRepository = treatmentRepository;
        }
        public HospitalTreatment ApproveHospitalTreatment(HospitalTreatment hospitalTreatment)
        {
            HospitalTreatment treatment = (HospitalTreatment)treatmentRepository.GetObject(hospitalTreatment.Id);
            treatment.Status = Status.Approved;
            return (HospitalTreatment)treatmentRepository.Update(treatment);
        }
        public Treatment CreateTreatment(Treatment treatment)
        {
            if (treatment.IsPrescription())
            {
                Prescription prescription = (Prescription)treatment;
                return treatmentRepository.Update(treatment);
            }
            if (treatment.IsHospitalTreatment())
                notificationService.NewHospitalTreatment((HospitalTreatment)treatment);
            return treatmentRepository.Create(treatment);
        }

        public bool DeleteTreatment(Treatment treatment) =>
            treatmentRepository.Delete(treatment);

        public List<Prescription> GetAllPrescriptions() =>
            treatmentRepository.GetAllPrescriptions();

        public List<Prescription> GetAllPrescriptionsInPeriodOfTime(DateTime startDate, DateTime endDate) =>
            treatmentRepository.GetAllPrescriptionsInPeriod(startDate, endDate);

        public List<HospitalTreatment> GetUnapprovedHospitalTreatments()
        {
            List<HospitalTreatment> allHospitalTreatments = (new List<HospitalTreatment>(treatmentRepository.GetAllHospitalTreatments()));
            List<HospitalTreatment> unapprovedTreatments = new List<HospitalTreatment>();
            foreach (HospitalTreatment hospitalTreatment in allHospitalTreatments)
                if (!hospitalTreatment.IsApproved())
                    unapprovedTreatments.Add(hospitalTreatment);
            return unapprovedTreatments;
        }

        public HospitalTreatment RejectHospitalTreatment(HospitalTreatment hospitalTreatment)
        {
            HospitalTreatment treatment = (HospitalTreatment)treatmentRepository.GetObject(hospitalTreatment.Id);
            treatment.Status = Status.Rejected;
            return (HospitalTreatment)treatmentRepository.Update(treatment);
        }
        public Treatment UpdateTreatment(Treatment treatment) =>
            treatmentRepository.Update(treatment);
 
    }

    

       
}