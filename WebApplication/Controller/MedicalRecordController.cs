using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Records.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;
using WebApplication.DTO;
using WebApplicationService.RecordsService;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private MedicalRecordsWebService medicalRecordService;

        public MedicalRecordController()
        {
            medicalRecordService = new MedicalRecordsWebService();
        }

        [HttpGet] // GET api/medicalrecord
        public IActionResult GetMedicalRecordByPatient(string id)
        {
            MedicalRecord medicalRecord = medicalRecordService.GetMedicalRecordByPatient(id);
            MedicalRecordDTO medicalRecordDTO = MedicalRecordAdapter.MedicalRecordToMedicalRecordDTO(medicalRecord);
            return Ok(medicalRecordDTO);
        }
    }
}
