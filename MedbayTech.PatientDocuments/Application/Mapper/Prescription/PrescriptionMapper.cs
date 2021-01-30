using MedbayTech.PatientDocuments.Application.DTO.Prescription;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.Mapper
{
    public class PrescriptionMapper
    {
        public static List<PrescriptionDTO> ListPrescriptionToPrescriptionDTO(List<Prescription> prescriptions)
        {
            List<PrescriptionDTO> prescriptionDTOs = new List<PrescriptionDTO>();

            foreach (Prescription p in prescriptions)
            {
                String name = p.Medication;
                int hourlyIntake = p.HourlyIntake;
                DateTime date = p.Date;

                prescriptionDTOs.Add(new PrescriptionDTO(name, hourlyIntake, date));
            }

            return prescriptionDTOs;
        }

        public static List<AppointmentPrescriptionDTO> ListPrescriptionToAppointmentPrescriptionDTO(List<Prescription> prescriptions)
        {
            List<AppointmentPrescriptionDTO> prescriptionDTOs = new List<AppointmentPrescriptionDTO>();

            foreach (Prescription p in prescriptions)
            {
                String name = p.Medication;
                int hourlyIntake = p.HourlyIntake;
                DateTime from = p.StartDate;
                DateTime to = p.EndDate;

                prescriptionDTOs.Add(new AppointmentPrescriptionDTO(name, hourlyIntake, from, to));
            }

            return prescriptionDTOs;
        }
    }
}
