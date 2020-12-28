// File:    Allergens.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 5:31:19 PM
// Purpose: Definition of Class Allergens

using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Rooms.Domain
{
    public class Allergens : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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