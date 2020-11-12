// File:    TreatmentController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 3:29:31 AM
// Purpose: Definition of Class TreatmentController

using Backend.Examinations.Model;
using Backend.Examinations.Service;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller
{
   public class TreatmentController
   {
        public TreatmentController(TreatmentService treatmentService)
        {
            this.treatmentService = treatmentService;
        }

        public Treatment CreateTreatment(Treatment treatment) => 
            treatmentService.CreateTreatment(treatment);

        public Treatment UpdateTreatment(Treatment treatment) => 
            treatmentService.UpdateTreatment(treatment);

        public bool DeleteTreatment(Treatment treatment) => 
            treatmentService.DeleteTreatment(treatment);

        public IEnumerable<HospitalTreatment> GetUnapprovedHospitalTreatments() => 
            treatmentService.GetUnapprovedHospitalTreatments();

        public IEnumerable<Prescription> GetAllPrescriptions() => 
            treatmentService.GetAllPrescriptions();

        public IEnumerable<Prescription> GetPrescriptionsInPeriod(DateTime startDate, DateTime endDate) => 
            treatmentService.GetAllPrescriptionsInPeriodOfTime(startDate, endDate);

        public HospitalTreatment ApproveHospitalTreatment(HospitalTreatment hospitalTreatment) => 
            treatmentService.ApproveHospitalTreatment(hospitalTreatment);

        public TreatmentService treatmentService;
   
   }
}