// File:    Allergens.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:31:19 PM
// Purpose: Definition of Class Allergens

using System;

namespace Model.Medications
{
   public class Allergens
   {
        private string allergen;
        public Allergens(string allergen)
        {
            this.Allergen = allergen;
        }

        public string Allergen { get => allergen; set => allergen = value; }
    }
}