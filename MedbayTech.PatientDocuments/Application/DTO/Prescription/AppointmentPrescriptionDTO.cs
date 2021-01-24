using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.DTO.Prescription
{
    public class AppointmentPrescriptionDTO
    {
        public string Medication { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int HourlyIntake { get; set; }

        public AppointmentPrescriptionDTO(string medication, int hourlyIntake, DateTime from, DateTime to)
        {
            Medication = medication;
            HourlyIntake = hourlyIntake;
            ValidFrom = from;
            ValidTo = to;
        }
    }
}
