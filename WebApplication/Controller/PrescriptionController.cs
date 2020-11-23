using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Examinations.Model;
using Backend.Examinations.WebApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Adapters;
using WebApplication.DTO;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private PrescriptionWebController prescriptionWebController;

        public PrescriptionController()
        {
            this.prescriptionWebController = new PrescriptionWebController();
        }

        [HttpGet] // GET api/medicalRecord
        public IActionResult GetAllPrescriptions()
        {
            List<Prescription> prescriptions = prescriptionWebController.GetAllPrescriptions().ToList();
            List<PrescriptionDTO> prescriptionDTOs = PrescriptionAdapter.ListAllPrescriptionToPrescriptionDTO(prescriptions);
            return Ok(prescriptionDTOs);
        }
    }
}
