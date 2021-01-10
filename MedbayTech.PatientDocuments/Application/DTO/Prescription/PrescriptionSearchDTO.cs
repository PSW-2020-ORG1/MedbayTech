using System;


namespace MedbayTech.PatientDocuments.Application.DTO.Prescription
{
    public class PrescriptionSearchDTO
    {
        public string Medicine { get; set; }
        public int HourlyIntake { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PrescriptionSearchDTO(string medication, int hourlyIntake, DateTime date)
        {
            Medicine = medication;
            HourlyIntake = hourlyIntake;
            StartDate = date;
            EndDate = date;
        }
    }
}
