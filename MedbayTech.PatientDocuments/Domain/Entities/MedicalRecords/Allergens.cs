// File:    Allergens.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:31:19 PM
// Purpose: Definition of Class Allergens

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Common;


namespace MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords
{
    public class Allergens
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Allergen { get; set; }
        public int MedicalRecordId { get; set; }
        public int MedicationId { get; set; }
        public Allergens() { }
        public Allergens(string allergen)
        {
            Allergen = allergen;
        }

    }
}