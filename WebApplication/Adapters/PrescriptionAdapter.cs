using Backend.Examinations.Model;
using Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class PrescriptionAdapter
    {

        public static List<PrescriptionDTO> ListAllPrescriptionToPrescriptionDTO(List<Prescription> prescriptions)
        {
            List<PrescriptionDTO> allPrescriptionList = new List<PrescriptionDTO>();
            foreach (Prescription pres in prescriptions)
            {
                int id = pres.Id;
                DateTime startDate = DateTime.Now;
                DateTime endDate = DateTime.Now;
                string medicine = "";
                if (pres.Medication != null)
                {
                    medicine = pres.Medication.Med;
                  
                }
                int hour = pres.HourlyIntake;
                allPrescriptionList.Add(new PrescriptionDTO(id, medicine, hour, new Period(startDate,endDate)));
            }

            return allPrescriptionList;

            
        }

    }
}
