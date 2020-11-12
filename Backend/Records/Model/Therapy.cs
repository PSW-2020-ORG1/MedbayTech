// File:    Therapy.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 10:53:47 PM
// Purpose: Definition of Class Therapy

using System;
using Backend.Medications.Model;
namespace Backend.Records.Model
{
   public class Therapy
   {
        public int Id { get; set; }
        public int HourConsumption { get; set; }
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        public Therapy() {}
        public Therapy(int hourConsumption, Medication medication)
        {
            HourConsumption = hourConsumption;
            Medication = medication;
        }

       
    }
}