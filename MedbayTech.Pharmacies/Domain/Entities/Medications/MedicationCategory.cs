// File:    MedicationCategory.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:28:21 PM
// Purpose: Definition of Class MedicationCategory

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Entities;

namespace MedbayTech.Pharmacies.Domain.Entities.Medications
{
    public class MedicationCategory : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public MedicationCategory() { }
        public MedicationCategory(string categoryName)
        {
            CategoryName = categoryName;
        }

        public int GetId()
        {
            return Id;
        }

    }
}