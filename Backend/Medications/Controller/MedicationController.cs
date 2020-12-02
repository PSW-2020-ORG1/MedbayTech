// File:    MedicationController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:45:03 AM
// Purpose: Definition of Class MedicationController

using Backend.Medications.Model;
using System;
using System.Collections.Generic;
using Model.Users;
using Backend.Medications.Service;

namespace Backend.Medications.Controller
{
   public class MedicationController
   {  

        public MedicationController(MedicationService medicationService) 
        {
            this.medicationService = medicationService;

        }    

        public Medication CreateMedication(Medication medication) => 
            medicationService.CreateMedication(medication);
        public Medication UpdateMedication(Medication medication) => 
            medicationService.UpdateMedication(medication);
        public bool DeleteMedication(Medication medication) => 
            medicationService.DeleteMedication(medication);
        public Medication GetMedication(int id) =>
            medicationService.GetMedication(id);
        /*public IEnumerable<Medication> GetAllOnValidationFor(Doctor doctor) => 
            medicationService.GetAllOnValidationFor(doctor);*/
        public IEnumerable<Medication> GetAllOnValidation() => 
            medicationService.GetAllOnValidation();
        public IEnumerable<Medication> GetAll() => 
            medicationService.GetAll();
        public IEnumerable<Medication> GetAllRejected() => 
            medicationService.GetAllRejected();
        public IEnumerable<Medication> GetAllApproved() => 
            medicationService.GetAllApproved();
        public Medication AddAmount(Medication medication, int amount) => 
            medicationService.AddAmount(medication, amount);
        public Medication RejectMedication(Medication medication) => 
            medicationService.RejectMedication(medication);
        public Medication ApproveMedication(Medication medication) => 
            medicationService.ApproveMedication(medication);
        public Medication UpdateSideEffects(Medication medication, SideEffect sideEffect) =>
            medicationService.UpdateSideEffects(medication, sideEffect);
        public Medication UpdateDosageOfIngerdients(Medication medication, DosageOfIngredient dosageOfIngredient) =>
            medicationService.UpdateDosageOfIngredients(medication, dosageOfIngredient);
        public Medication UpdateAllegens(Medication medication, Allergens allergens) =>
            medicationService.UpdateAllergens(medication, allergens);


        public MedicationService medicationService;
   
   }
}