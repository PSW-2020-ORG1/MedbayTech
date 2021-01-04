using MedbayTech.PatientDocuments.Application.Common.Interfaces.Service;
using MedbayTech.PatientDocuments.Application.DTO;
using MedbayTech.PatientDocuments.Application.Exception;
using MedbayTech.PatientDocuments.Application.Mapper;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using Microsoft.AspNetCore.Mvc;
using System;


namespace MedbayTech.PatientDocuments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpGet]
        public IActionResult GetMedicalRecordByPatient()
        {
            try
            {
                MedicalRecord medicalRecord = _medicalRecordService.GetMedicalRecordByPatient("2406978890046");
                MedicalRecordDTO medicalRecordDTO = MedicalRecordMapper.MedicalRecordToMedicalRecordDTO(medicalRecord);
                return Ok(medicalRecordDTO);
            }
            catch (EntityNotFound)
            {
                return BadRequest("Medical record not found.");
            }
            catch (Exception)
            {
                return BadRequest("Inner system error.");
            }

        }

        [HttpGet("{textBoxSearch?}")]
        public IActionResult GetMedicalRecordByPatientId(string textBoxSearch)
        {
            return Ok(_medicalRecordService.GetMedicalRecordByPatient(textBoxSearch));
        }
    }
}
