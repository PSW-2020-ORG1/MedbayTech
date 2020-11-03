/***********************************************************************
 * Module:  Medication.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.Medication
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimsProjekat.Repository;

namespace Model.Medications
{
   public class Medication : IIdentifiable<int>
   {

        private int medId;
        private string med;
        private MedStatus status;
        private string company;
        private int quantity;
        private List<DosageOfIngredient> medicationContent;
        private List<MedicationCategory> medicationCategory;
        private List<Allergens> allergens;
        private List<Medication> alternativeMedication;
        private List<SideEffect> sideEffects;

        [Key]
        public int MedId { get => medId; set => medId = value; }
        public string Med { get => med; set => med = value; }
        public MedStatus Status { get => status; set => status = value; }
        public string Company { get => company; set => company = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public virtual List<DosageOfIngredient> MedicationContent { get => medicationContent; set => medicationContent = value; }
        public virtual List<MedicationCategory> MedicationCategory { get => medicationCategory; set => medicationCategory = value; }
        public virtual List<Allergens> Allergens { get => allergens; set => allergens = value; }
        public virtual List<Medication> AlternativeMedication { get => alternativeMedication; set => alternativeMedication = value; }
        public virtual List<SideEffect> SideEffects { get => sideEffects; set => sideEffects = value; }

        public Medication() 
        {
            Allergens = new List<Allergens>();
            SideEffects = new List<SideEffect>();
            MedicationCategory = new List<MedicationCategory>();
            MedicationContent = new List<DosageOfIngredient>();
        }
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
            MedId = id;
        }

        public int GetId()
        {
            return MedId;
        }

        public void SetId(int id)
        {
            MedId = id;
        }
    }
}