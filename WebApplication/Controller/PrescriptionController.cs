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
using WebApplication.Validators;

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

        [HttpPost("advancedSearch")]
        public IActionResult AdvancedSearchPrescriptions(PrescriptionAdvancedDTO dto)
        {
            try
            {
                ValidatePrescriptionSearchInput.Validate(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            List<Prescription> prescriptions = prescriptionWebController.AdvancedSearchPrescriptions(dto);

            return Ok(prescriptions);
        }
    }
}
