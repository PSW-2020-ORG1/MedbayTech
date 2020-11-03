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
        private string name;
        private int id;

        public MedicationIngredient() { }
        public MedicationIngredient(string name)
        {
            this.Name = name;
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}