using System;
using System.Collections.Generic;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Service.Treatments;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using Microsoft.AspNetCore.Mvc;
using MedbayTech.PatientDocuments.Application.DTO.Prescription;
using MedbayTech.PatientDocuments.Application.Mapper;
using MedbayTech.PatientDocuments.Application.Validators.Prescription;

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
                PrescriptionSearchValidator.Validate(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            List<Prescription> prescriptions = _prescriptionSearchService.GetSearchedPrescription(dto.Medicine, dto.HourlyIntake, dto.StartDate, dto.EndDate);
            List<PrescriptionDTO> prescriptionDTOs = PrescriptionMapper.ListPrescriptionToPrescriptionDTO(prescriptions);

            return Ok(prescriptionDTOs);
        }

        [HttpPost("advancedSearch")]
        public IActionResult AdvancedSearchPrescriptions(PrescriptionAdvancedDTO dto)
        {
            try
            {
                PrescriptionSearchInputValidator.Validate(dto);
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }

            List<Prescription> prescriptions = _prescriptionSearchService.AdvancedSearchPrescriptions(dto);

            return Ok(prescriptions);
        }

        [HttpGet("all")]
        public IActionResult GetAllForPharmacies()
        {
            return Ok(_prescriptionSearchService.GetAllForSending());
        }


        [HttpPost("generate")]
        public IActionResult GenerateReport(PrescriptionForSendingDTO prescription)
        {
            return Ok(_prescriptionSearchService.GeneratePrescription(prescription));
        }



    }
}
