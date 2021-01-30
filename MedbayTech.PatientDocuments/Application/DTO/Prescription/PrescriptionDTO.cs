using System;

namespace MedbayTech.PatientDocuments.Application.DTO.Prescription
{
    public class PrescriptionDTO
    {
        public string Medicine { get; set; }
        public int HourlyIntake { get; set; }
        public DateTime Date { get; set; }

        public PrescriptionDTO(string medication, int hourlyIntake, DateTime date)
        {
            Medicine = medication;
            HourlyIntake = hourlyIntake;
            Date = date;
        }
    }
}
