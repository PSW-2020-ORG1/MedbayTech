/***********************************************************************
 * Module:  Medication.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.Medication
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Examinations.Model;
using Backend.General.Model;
using Model.Rooms;

namespace Backend.Medications.Model
{
   public class Medication : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public string Med { get; set; }
        public MedStatus Status { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        [ForeignKey ("Room")]
        public int RoomId { get; set; } 
        public virtual Room Room { get; set; }
        public virtual List<DosageOfIngredient> MedicationContent { get; set; }
        [ForeignKey("MedicationCategory")]
        public int MedicationCategoryId { get; set; }
        public virtual MedicationCategory MedicationCategory { get; set; }
        public virtual List<Allergens> Allergens { get; set; }
        public virtual List<Medication> AlternativeMedication { get; set; }
        public virtual List<SideEffect> SideEffects { get; set; }
        public Medication() { }

        public Medication(string name, string company, MedicationCategory category)
        {
            Med = name;
            Company = company;
            MedicationContent = new List<DosageOfIngredient>();
            MedicationCategory = category;
            MedicationCategoryId = category.Id;
            Allergens = new List<Allergens>();
            SideEffects = new List<SideEffect>();
            Status = MedStatus.Validation;
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

        public bool IsOnValidation()
        {
            return Status == MedStatus.Validation;
        }
    }
}