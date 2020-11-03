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
        public string CategoryName { get; set; }
        public virtual Specialization Specialization { get; set; }
        public int Id { get; set; }
        public int SpecializationId { get; set; }

        public MedicationCategory() {}
        public MedicationCategory(string categoryName, Specialization specialization)
        {
            this.CategoryName = categoryName;
            this.Specialization = specialization;
        }

        
    }
}