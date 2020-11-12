// File:    MedicationCategory.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:28:21 PM
// Purpose: Definition of Class MedicationCategory

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Users;

namespace Backend.Medications.Model
{
    public class MedicationCategory
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }
        [ForeignKey("Medication")]
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }
        public MedicationCategory() {}
        public MedicationCategory(string categoryName, Specialization specialization)
        {
            CategoryName = categoryName;
            Specialization = specialization;
        }

        
    }
}