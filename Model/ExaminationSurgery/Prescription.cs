// File:    Prescription.cs
// Author:  Vlajkov
// Created: Tuesday, April 07, 2020 12:22:01 AM
// Purpose: Definition of Class Prescription

using System;
using System.Collections.Generic;
using Model.Medications;

namespace Examinations
{
   public class Prescription : Treatment
   {
        public bool Reserved { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public int HourlyIntake { get; set; }
        public virtual List<Medication> Medications { get; set; }

        public Prescription() { }
     /*   public Prescription()
        {
            Medications = new List<Medication>();
        } */
        public Prescription(DateTime dateOfPrescription, bool reserved, int hourlyIntake, string additionalNotes, List<Medication> medications)
            : base(dateOfPrescription, additionalNotes, TreatmentType.prescription)
        {
            Reserved = reserved;
            if (Reserved)
            {
                ReservedFrom = DateTime.Today.Date;
                ReservedTo = DateTime.Today.Date.AddDays(10);
            }
            HourlyIntake = hourlyIntake;
            Medications = medications;
        }

        public Prescription(int id) : base(id) { }
    }
}