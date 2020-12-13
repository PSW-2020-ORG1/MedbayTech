using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Examinations.Service;
using Backend.Examinations.Service.Interfaces;
using Backend.Examinations.Model;

namespace PharmacyIntegration.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        IPrescriptionSearchService prescriptionSearchService;

        public PrescriptionController(IPrescriptionSearchService prescriptionSearchService)
        {
            this.prescriptionSearchService = prescriptionSearchService;
        }

        [HttpGet]
        public IEnumerable<Prescription> Get()
        {
            return prescriptionSearchService.GetAll();
        }




    }
}
