using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Examinations.WebApiService
{
    public class PrescriptionSearchWebService
    {
        private IPrescriptionRepository repository;

        public PrescriptionSearchWebService(IPrescriptionRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Prescription> GetSearchedPrescription(string medicationName, int hourlyIntake, DateTime startDate, DateTime endDate)
        {
            List<Prescription> prescriptions = repository.GetAll().ToList();
            List<Prescription> iterationList = new List<Prescription>(prescriptions);

            foreach(Prescription prescription in iterationList)
            {
                if (!prescription.Medication.Med.ToLower().Equals(medicationName.ToLower()) && !medicationName.Equals("")) {
                    prescriptions.Remove(prescription);
                }

                if (!(prescription.HourlyIntake == hourlyIntake))
                {
                    prescriptions.Remove(prescription);
                }

                if (prescription.Date <= startDate || prescription.Date >= endDate)
                {
                    prescriptions.Remove(prescription);
                } 
            }

            return prescriptions;
        }
    }
}
