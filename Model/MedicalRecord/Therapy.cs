// File:    Therapy.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 10:53:47 PM
// Purpose: Definition of Class Therapy

using System;
using Model.Medications;
namespace Model.MedicalRecord
{
   public class Therapy
   {
        private int hourConsumption;
      
        private Medication medication;

        public Therapy(int hourConsumption, Medication medication)
        {
            HourConsumption = hourConsumption;
            Medication = medication;
        }

        public int HourConsumption { get => hourConsumption; set => hourConsumption = value; }
        public Medication Medication { get => medication; set => medication = value; }
    }
}