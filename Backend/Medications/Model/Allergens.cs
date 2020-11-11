// File:    Allergens.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:31:19 PM
// Purpose: Definition of Class Allergens

using System;
using Model.MedicalRecord;


namespace Backend.Medications.Model
{
    public class Allergens
    {

        public int Id { get; set; }
        public string Allergen { get; set; }

        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        public Allergens() { }
        public Allergens(string allergen)
        {
            Allergen = allergen;
        }

    }
}