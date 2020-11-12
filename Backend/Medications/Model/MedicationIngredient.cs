/***********************************************************************
 * Module:  MedicationContent.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.MedicationContent
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Medications.Model
{
   public class MedicationIngredient
    {
        [Key]
        public int Id { get; set; }
        public  string Name { get; set; }

        public MedicationIngredient() { }
        public MedicationIngredient(string name)
        {
            Name = name;
        }

        
        
    }
}