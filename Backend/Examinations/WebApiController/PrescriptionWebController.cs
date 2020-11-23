using Backend.Examinations.Model;
using Backend.Examinations.Repository.MySqlRepository;
using Backend.Examinations.WebApiService;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.WebApiController
{
    public class PrescriptionWebController
    {
        private PrescriptionSqlRepository prescriptionSqlRepository = new PrescriptionSqlRepository(new MySqlContext());
        private PrescriptionWebService prescriptionWebService;

        public PrescriptionWebController()
        {
            this.prescriptionWebService = new PrescriptionWebService(prescriptionSqlRepository);
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return prescriptionWebService.GetAllPrescriptions();
        }
    }
}
