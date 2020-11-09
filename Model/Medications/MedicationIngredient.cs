/***********************************************************************
 * Module:  MedicationContent.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.MutualClasses.MedicationContent
 ***********************************************************************/

using System;

namespace Model.Medications
{
   public class MedicationIngredient
   {
        public  string Name { get; set; }
        public int Id { get; set; }

        public MedicationIngredient() { }
        public MedicationIngredient(string name)
        {
            this.Name = name;
        }

        
        
    }
}