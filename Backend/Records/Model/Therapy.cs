// File:    Therapy.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 10:53:47 PM
// Purpose: Definition of Class Therapy

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Medications.Model;
namespace Backend.Records.Model
{
   public class Therapy
   {
        [Key]
        public int Id { get; set; }
        public int HourConsumption { get; set; }
        
        [ForeignKey("Medication")]
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        public Therapy() {}
        public Therapy(int hourConsumption, Medication medication)
        {
            HourConsumption = hourConsumption;
            Medication = medication;
        }

       
    }
}