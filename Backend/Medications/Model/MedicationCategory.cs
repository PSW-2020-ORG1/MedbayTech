// File:    MedicationCategory.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:28:21 PM
// Purpose: Definition of Class MedicationCategory

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Users;
using Backend.General.Model;

namespace Backend.Medications.Model
{
    public class MedicationCategory : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }
        public MedicationCategory() {}
        public MedicationCategory(string categoryName, Specialization specialization)
        {
            CategoryName = categoryName;
            Specialization = specialization;
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