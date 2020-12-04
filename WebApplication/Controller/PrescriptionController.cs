using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Examinations.Model;
using Backend.Examinations.Service.Interfaces;
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
        private IPrescriptionSearchService _prescriptionSearchService;

        public PrescriptionController(IPrescriptionSearchService prescriptionSearchService)
        {
            _prescriptionSearchService = prescriptionSearchService;
        }

        [HttpPost]
        public IActionResult GetSearchedPrescription(PrescriptionSearchDTO dto)
        {
            try
            {
                ValidatePrescriptionsSearch.Validate(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            List<Prescription> prescriptions = _prescriptionSearchService.GetSearchedPrescription(dto.Medicine, dto.HourlyIntake, dto.StartDate, dto.EndDate);
            List<PrescriptionDTO> prescriptionDTOs = PrescriptionsAdapter.ListPrescriptionToPrescriptionDTO(prescriptions);

            return Ok(prescriptionDTOs);
        }

        [HttpPost("advancedSearch")]
        public IActionResult AdvancedSearchPrescriptions(PrescriptionAdvancedDTO dto)
        {
            try
            {
                ValidatePrescriptionSearchInput.Validate(dto);
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }

            List<Prescription> prescriptions = _prescriptionSearchService.AdvancedSearchPrescriptions(dto);

            return Ok(prescriptions);
        }
    }
}
