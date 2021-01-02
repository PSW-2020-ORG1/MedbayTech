// File:    Prescription.cs
// Author:  Vlajkov
// Created: Tuesday, April 07, 2020 12:22:01 AM
// Purpose: Definition of Class Prescription

using System;
using Backend.Examinations.Model.Enums;

namespace MedbayTech.PatientDocuments.Domain.Entities.Treatment
{
    public class Prescription : Treatment
    {
        private const int RESERVATION_DAYS = 10;
        public bool Reserved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HourlyIntake { get; set; }
        public int MedicationId { get; set; }
        public string Medication { get; set; }

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

        public string GetStringForSharing()
        {
            string result = "\t\tPRESCRIPTION\t\t" + "\n\nPatient Ifnormation\t\n" +
                "\tName: " + Report.MedicalRecord.Patient.Name +
                "\n\tSurname: " + Report.MedicalRecord.Patient.Surname +
                "\n\tIndetification Number: " + Report.MedicalRecord.Patient.Id +
                "\n\nMedication Information" +
                "\n\tMedication name: " + Medication +
                "\n\tHourly Intake: " + HourlyIntake +
                "\n\n\t\t\t Doctor: " +
                "\n\t\t " + "Dr. " + Report.Doctor.Surname + ", " + Report.Doctor.Name +
                "\n\t\t Date: " + Date;
            return result;
        }

    }
}