// File:    Prescription.cs
// Author:  Vlajkov
// Created: Tuesday, April 07, 2020 12:22:01 AM
// Purpose: Definition of Class Prescription

using System;
using System.Collections.Generic;
using Backend.Examinations.Model.Enums;

namespace Backend.Examinations.Model
{
   public class Prescription : Treatment
    {
        private const int RESERVATION_DAYS = 10; 
        public bool Reserved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HourlyIntake { get; set; }
        public int MedicationId { get; set; }

        public Prescription() : base(TreatmentType.Prescription)
        {
            Date = DateTime.Today;
        }

        public Prescription(DateTime dateOfPrescription, bool reserved, int hourlyIntake, string additionalNotes)
            : base(dateOfPrescription, additionalNotes, TreatmentType.Prescription)
        {
            Reserved = reserved;
            if (Reserved)
            {
                StartDate = DateTime.Today;
                EndDate = DateTime.Today.AddDays(RESERVATION_DAYS);
            }
            HourlyIntake = hourlyIntake;
        }

        public Prescription(int id) : base(id) { }

        public bool IsStillActive(DateTime startDate, DateTime endDate)
        {
            return Date.CompareTo(startDate) > 0 &&
                   Date.CompareTo(endDate) < 0;
        }

    }
}