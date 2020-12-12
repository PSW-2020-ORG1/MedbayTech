/***********************************************************************
 * Module:  MedicationContent.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.MedicationContent
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Backend.General.Model;

namespace Backend.Medications.Model
{
   public class MedicationIngredient : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public  string Name { get; set; }

        public MedicationIngredient() { }
        public MedicationIngredient(string name)
        {
            Name = name;
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