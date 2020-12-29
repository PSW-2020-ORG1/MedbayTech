using System;
using System.Collections.Generic;
using Backend.Examinations.Service.Interfaces;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using Microsoft.AspNetCore.Mvc;

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
        /*
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
        }*/
    }
}
