/***********************************************************************
 * Module:  Medication.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.Medication
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.ExaminationSurgery;
using SimsProjekat.Repository;

namespace Model.Medications
{
   public class Medication : IIdentifiable<int>
   {

        public int Id { get; set;  }
        public string Med { get; set; }
        public MedStatus Status { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public List<DosageOfIngredient> MedicationContent { get; set; }
        public List<MedicationCategory> MedicationCategory { get; set; }
        private List<Allergens> Allergens { get; set; }

        public List<Medication> AlternativeMedication { get; set; }
        public List<SideEffect> SideEffects { get; set; }

        public int PerscriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public int TreatmentFormId { get; set; }

        public virtual TreatmentForm TreatmentForm { get; set; }
        
        
        public Medication() { }

        public Medication(string name, string company, List<DosageOfIngredient> ingredients, List<MedicationCategory> category, List<Allergens> allergens, List<SideEffect> sideEffects)
        {
            Med = name;
            Company = company;
            MedicationContent = ingredients;
            MedicationCategory = category;
            Allergens = allergens;
            SideEffects = sideEffects;
            Status = MedStatus.validation;
        }

        public Medication(int id)
        {
            Id = id;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}