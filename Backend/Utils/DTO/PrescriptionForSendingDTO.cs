using System;
using System.Collections.Generic;
using System.Text;
using Backend.Examinations.Model;

namespace Backend.Utils.DTO
{
    public class PrescriptionForSendingDTO
    {
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientId { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDosage { get; set; }
        public int MedicationHourlyIntake { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public DateTime Date { get; set; }

        public PrescriptionForSendingDTO()
        { }

        public PrescriptionForSendingDTO(string patientName, string patineSurname, string patientId, string medicationName, string medicationDosage, int medicationHourlyIntake, string doctorName, string doctorSurname, DateTime date)
        {
            PatientName = patientName;
            PatientSurname = patineSurname;
            PatientId = patientId;
            MedicationName = medicationName;
            MedicationDosage = medicationDosage;
            MedicationHourlyIntake = medicationHourlyIntake;
            DoctorName = doctorName;
            DoctorSurname = doctorSurname;
            Date = date;
        }

        public PrescriptionForSendingDTO(Prescription prescription)
        {
            PatientName = prescription.ExaminationSurgery.MedicalRecord.Patient.Name;
            PatientSurname = prescription.ExaminationSurgery.MedicalRecord.Patient.Surname;
            PatientId = prescription.ExaminationSurgery.MedicalRecord.Patient.Id;
            MedicationName = prescription.Medication.Med;
            MedicationDosage = prescription.Medication.Dosage;
            MedicationHourlyIntake = prescription.HourlyIntake;
            DoctorSurname = prescription.ExaminationSurgery.Doctor.Surname;
            DoctorName = prescription.ExaminationSurgery.Doctor.Name;
            Date = prescription.Date;
        }

        public override string ToString()
        {
            string result = "\t\tPRESCRIPTION\t\t" + "\n\nPatient Information\t\n" +
                "\tName: " + PatientName +
                "\n\tSurname: " + PatientSurname +
                "\n\tIndetification Number: " + PatientId +
                "\n\nMedication Information" +
                "\n\tMedication name: " + MedicationName +
                "\n\tDosage: " + MedicationDosage +
                "\n\tHourly Intake: " + MedicationHourlyIntake +
                "\n\n\t\t\t Doctor: " +
                "\n\t\t " + "Dr. " + DoctorSurname + ", " + DoctorName +
                "\n\t\t Date: " + Date;
            return result;
        }

        public string FileName()
        {
            return PatientId + "_" + MedicationName + "_" + Date.Day + "_" + Date.Month + "_" + Date.Year;
        }
    }
}
