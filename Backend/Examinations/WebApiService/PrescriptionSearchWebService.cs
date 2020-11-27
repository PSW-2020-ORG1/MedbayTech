using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.WebApiService
{
    public class PrescriptionSearchWebService
    {
        private ITreatmentRepository repository;

        public PrescriptionSearchWebService(ITreatmentRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Treatment> GetSearchedPrescription(string medicationName, int hourlyIntake, DateTime startDate, DateTime endDate)
        {
            return repository.GetSearchedPrescription(medicationName, hourlyIntake, startDate, endDate);
        }
    }
}
