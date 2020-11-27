using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Examinations.WebApiService
{
    public class PrescriptionWebService
    {
        private IPrescriptionRepository prescriptionRepository;

        public PrescriptionWebService(IPrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        
        public IEnumerable<Prescription> GetSearchedPrescriptions(int hourlyIntake, string medication, List<string> operators)
        {
            List<Prescription> prescriptions = prescriptionRepository.GetAllPrescriptions().ToList();
            List<Prescription> filteredPrescriptions = new List<Prescription>(prescriptions);
            
            foreach(Prescription prescription in prescriptions)
            {
                if (prescription.HourlyIntake != hourlyIntake || !prescription.Medication.Med.ToLower().Equals(medication.ToLower()))
                    filteredPrescriptions.Remove(prescription);
            }

            return filteredPrescriptions;
        }
    }
}
