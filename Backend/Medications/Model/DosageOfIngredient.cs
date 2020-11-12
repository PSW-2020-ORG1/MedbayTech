// File:    DosageOfIngredient.cs
// Author:  Vlajkov
// Created: Saturday, April 18, 2020 5:40:32 PM
// Purpose: Definition of Class DosageOfIngredient

using System;

namespace Backend.Medications.Model
{
    public class DosageOfIngredient
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int MedicationIngredientId { get; set; }

        public virtual MedicationIngredient MedicationIngredient { get; set; }

        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }
        public DosageOfIngredient() {}
        public DosageOfIngredient(MedicationIngredient ingredient, double amount)
        {
            this.MedicationIngredient = ingredient;
            this.Amount = amount;
        }

        
    }
}