// File:    DosageOfIngredient.cs
// Author:  Vlajkov
// Created: Saturday, April 18, 2020 5:40:32 PM
// Purpose: Definition of Class DosageOfIngredient

using System;

namespace Model.Medications
{
   public class DosageOfIngredient
   {
        private double amount;

        private MedicationIngredient medicationIngredient;

        public DosageOfIngredient(MedicationIngredient ingredient, double amount)
        {
            this.MedicationIngredient = ingredient;
            this.Amount = amount;
        }

        public double Amount { get => amount; set => amount = value; }
        public MedicationIngredient MedicationIngredient { get => medicationIngredient; set => medicationIngredient = value; }
    }
}