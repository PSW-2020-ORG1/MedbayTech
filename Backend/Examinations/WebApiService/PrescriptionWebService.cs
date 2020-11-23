using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return prescriptionRepository.GetAllPrescriptions();
        }
    }
}
