// File:    Allergens.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:31:19 PM
// Purpose: Definition of Class Allergens

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Records.Model;
using Backend.General.Model;


namespace Backend.Medications.Model
{
    public class Allergens : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public string Allergen { get; set; }
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        public Allergens() { }
        public Allergens(string allergen)
        {
            Allergen = allergen;
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