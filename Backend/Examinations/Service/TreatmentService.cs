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

namespace Backend.Examinations.Service
{
   public class TreatmentService
   {
        public TreatmentService(ITreatmentRepository treatmentRepository, NotificationService notificationService)
        {
            this.notificationService = notificationService;
            this.treatmentRepository = treatmentRepository;
        }

        public Treatment CreateTreatment(Treatment treatment)
        {
            if (treatment.IsPrescription())
            {
                Prescription prescription = (Prescription) treatment;
                prescription.InitializeReservationDates();
                return treatmentRepository.Update(treatment);
            }
            if (treatment.IsHospitalTreatment())
                notificationService.NewHospitalTreatment((HospitalTreatment) treatment);
            return treatmentRepository.Create(treatment);
        }
        public Treatment UpdateTreatment(Treatment treatment) => 
            treatmentRepository.Update(treatment);
        public bool DeleteTreatment(Treatment treatment) => 
            treatmentRepository.Delete(treatment);
        public IEnumerable<HospitalTreatment> GetUnapprovedHospitalTreatments()
        {
            List<HospitalTreatment> allHospitalTreatments = (new List<HospitalTreatment>(treatmentRepository.GetAllHospitalTreatments()));
            List<HospitalTreatment> unapprovedTreatments = new List<HospitalTreatment>();
            foreach (HospitalTreatment hospitalTreatment in allHospitalTreatments)
                if (!hospitalTreatment.IsApproved())
                    unapprovedTreatments.Add(hospitalTreatment);
            return unapprovedTreatments;
        }
        public IEnumerable<Prescription> GetAllPrescriptions() => 
            treatmentRepository.GetAllPrescriptions();

        public IEnumerable<Prescription> GetAllPrescriptionsInPeriodOfTime(DateTime startDate, DateTime endDate) => 
            treatmentRepository.GetAllPrescriptionsInPeriod(startDate, endDate);

        public HospitalTreatment ApproveHospitalTreatment(HospitalTreatment hospitalTreatment)
        {
            HospitalTreatment treatment = (HospitalTreatment)treatmentRepository.GetObject(hospitalTreatment.Id);
            treatment.Status = Status.Approved;
            return (HospitalTreatment) treatmentRepository.Update(treatment);
        }
        public HospitalTreatment RejectHospitalTreatment(HospitalTreatment hospitalTreatment)
        {
            HospitalTreatment treatment = (HospitalTreatment)treatmentRepository.GetObject(hospitalTreatment.Id);
            treatment.Status = Status.Rejected;
            return (HospitalTreatment)treatmentRepository.Update(treatment);
        }

        public NotificationService notificationService;
        public ITreatmentRepository treatmentRepository;
   
   }
}