// File:    MedicationController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:45:03 AM
// Purpose: Definition of Class MedicationController

using Model.Medications;
using System;
using System.Collections.Generic;
using Service.MedicationService;

namespace Controller.MedicationController
{
   public class MedicationController
   {  

        public MedicationController(MedicationService medicationService) 
        {
            this.medicationService = medicationService;

        }    

        public Medication CreateMedication(Medication medication) => medicationService.CreateMedication(medication);
        public Medication UpdateMedication(Medication medication) => medicationService.UpdateMedication(medication);
        public bool DeleteMedication(Medication medication) => medicationService.DeleteMedication(medication);
        public Medication GetMedication(int id) => medicationService.GetMedication(id);
        public IEnumerable<Medication> GetAllOnValidationForDoctor(Model.Users.Doctor doctor) => medicationService.GetAllOnValidationForDoctor(doctor);
        public IEnumerable<Medication> GetAllOnValidation() => medicationService.GetAllOnValidation();
        public IEnumerable<Medication> GetAll() => medicationService.GetAll();
        public IEnumerable<Medication> GetAllRejectedMeds() => medicationService.GetAllRejectedMeds();
        public IEnumerable<Medication> GetAllApprovedMeds() => medicationService.GetAllApprovedMeds();
        public Medication AddAmount(Medication medication, int amount) => medicationService.AddAmount(medication, amount);
        public Medication RejectMedication(Medication medication) => medicationService.RejectMedication(medication);
        public Medication ApproveMedication(Medication medication) => medicationService.ApproveMedication(medication);
      
        public MedicationService medicationService;
   
   }
}