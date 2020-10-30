// File:    MedicationCategory.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:28:21 PM
// Purpose: Definition of Class MedicationCategory

using System;
using Model.Users;

namespace Model.Medications
{
   public class MedicationCategory
   {
        private string categoryName;
        private Specialization specialization;

        public MedicationCategory(string categoryName, Specialization specialization)
        {
            this.CategoryName = categoryName;
            this.Specialization = specialization;
        }

        public string CategoryName { get => categoryName; set => categoryName = value; }
        public Specialization Specialization { get => specialization; set => specialization = value; }
    }
}