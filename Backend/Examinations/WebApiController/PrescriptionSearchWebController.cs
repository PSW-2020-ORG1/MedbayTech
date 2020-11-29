using Backend.Examinations.Model;
using Backend.Examinations.Repository.MySqlRepository;
using Backend.Examinations.WebApiService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Examinations.WebApiController
{
    public class PrescriptionSearchWebController
    {
        private PrescriptionsSqlRepository repository = new PrescriptionsSqlRepository(new MySqlContext());
        private PrescriptionSearchWebService service;

        public PrescriptionSearchWebController()
        {
            this.service = new PrescriptionSearchWebService(repository);
        }

        public List<Prescription> GetSearchedReports(string name, int hourlyIntake, DateTime startDate, DateTime endDate)
        {
            return service.GetSearchedPrescription(name, hourlyIntake, startDate, endDate).ToList();
        }
    }
}
