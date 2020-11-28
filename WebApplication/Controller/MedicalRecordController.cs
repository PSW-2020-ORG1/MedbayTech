using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Records.Model;
using Backend.Records.WebApiController;
using Backend.Records.WebApiService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;
using WebApplication.DTO;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private MedicalRecordWebController medicalRecordWebController;

        public MedicalRecordController()
        {
            medicalRecordWebController = new MedicalRecordWebController();
        }

        [HttpGet] // GET api/medicalRecord
        public IActionResult GetMedicalRecordByPatient()
        {
            MedicalRecord medicalRecord = medicalRecordWebController.GetMedicalRecordByPatientId("2406978890046");
            MedicalRecordDTO medicalRecordDTO = MedicalRecordAdapter.MedicalRecordToMedicalRecordDTO(medicalRecord);
            return Ok(medicalRecordDTO);
        }
    }
}
