using Backend.Examinations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class PrescriptionsAdapter
    {
        public static List<PrescriptionDTO> ListPrescriptionToPrescriptionDTO(List<Prescription> prescriptions)
        {
            List<PrescriptionDTO> prescriptionDTOs = new List<PrescriptionDTO>();

            foreach (Prescription p in prescriptions)
            {
                String name = p.Medication.Med;
                int hourlyIntake = p.HourlyIntake;
                DateTime date = p.StartDate;

                prescriptionDTOs.Add(new PrescriptionDTO(name, hourlyIntake, date));
            }

            return prescriptionDTOs;
        }
    }
}
