// File:    TreatmentService.cs
// Author:  Vlajkov
// Created: Monday, June 01, 2020 10:34:45 PM
// Purpose: Definition of Class TreatmentService

using Backend.Examinations.Model;
using Model.Users;
using Repository.ExaminationRepository;
using Service.GeneralService;
using System;
using System.Collections.Generic;
using Backend.Examinations.Model.Enums;
using Backend.Examinations.Model.Model.Enums;

namespace Service.ExaminationService
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
                return ReserveMedication(treatment);
            }

            if (treatment.IsHospitalTreatment())
            {
                notificationService.NewHospitalTreatment((HospitalTreatment) treatment);
            }

            return treatmentRepository.Create(treatment);
        }

        private Treatment ReserveMedication(Treatment treatment)
        {
            Prescription prescription = (Prescription)treatment;
            prescription.InitializeReservationDates();
            return treatmentRepository.Create(prescription);
        }

        public Treatment UpdateTreatment(Treatment treatment) => treatmentRepository.Update(treatment);
        public bool DeleteTreatment(Treatment treatment) => treatmentRepository.Delete(treatment);
        public IEnumerable<HospitalTreatment> GetUnapprovedHospitalTreatments()
        {
            var allHospitalTreatments = treatmentRepository.GetAllHospitalTreatments();
            List<HospitalTreatment> unapprovedTreatments = new List<HospitalTreatment>();
            foreach (HospitalTreatment hospitalTreatment in allHospitalTreatments)
            {
                if (!hospitalTreatment.IsApproved())
                {
                    unapprovedTreatments.Add(hospitalTreatment);
                }
            }
            return unapprovedTreatments;
        }
        public IEnumerable<Prescription> GetAllPrescriptions() => treatmentRepository.GetAllPrescriptions();

        public IEnumerable<Prescription> GetAllPrescriptionsInPeriodOfTime(DateTime startDate, DateTime endDate) => treatmentRepository.GetAllPrescriptionsInPeriodOfTime(startDate, endDate);   
        public HospitalTreatment ApproveHospitalTreatment(HospitalTreatment hospitalTreatment)
        {
            HospitalTreatment treatmentToUpdate = (HospitalTreatment)treatmentRepository.GetObject(hospitalTreatment.Id);
            treatmentToUpdate.Status = Status.Approved;
            return (HospitalTreatment)treatmentRepository.Update(treatmentToUpdate);
        }

        public NotificationService notificationService;
        public ITreatmentRepository treatmentRepository;
   
   }
}