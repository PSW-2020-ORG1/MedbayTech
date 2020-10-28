// File:    TreatmentService.cs
// Author:  Vlajkov
// Created: Monday, June 01, 2020 10:34:45 PM
// Purpose: Definition of Class TreatmentService

using Model.ExaminationSurgery;
using Model.Users;
using Repository.ExaminationRepository;
using Service.GeneralService;
using System;
using System.Collections.Generic;

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
            if (treatment is Prescription)
            {
                return ReserveMedication(treatment);
            } else if (treatment is HospitalTreatment)
            {
                notificationService.NewHospitalTreatment((HospitalTreatment)treatment);
            }

            return treatmentRepository.Create(treatment);
        }

        private Treatment ReserveMedication(Treatment treatment)
        {
            Prescription prescription = (Prescription)treatment;
            if (prescription.Reserved)
            {
                prescription.ReservedFrom = DateTime.Today.Date;
                prescription.ReservedTo = DateTime.Today.Date;
            }
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
                if (!hospitalTreatment.Approved)
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
            treatmentToUpdate.Approved = true;
            return (HospitalTreatment)treatmentRepository.Update(treatmentToUpdate);
        }

        public NotificationService notificationService;
        public ITreatmentRepository treatmentRepository;
   
   }
}