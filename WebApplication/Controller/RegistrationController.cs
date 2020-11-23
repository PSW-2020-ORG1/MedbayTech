using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Backend.Users.WebApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;
using WebApplication.DTO;

namespace WebApplication.Controller
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        WebRegistrationController registrationController;

        public RegistrationController()
        {
            this.registrationController = new WebRegistrationController();
        }
        [HttpGet("proba")]
        public IActionResult Proba()
        {
            return Ok("Uspesno");
        }
        [HttpPost("image"), DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        public IActionResult Image(string id)
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("patientRegistration"), DisableRequestSizeLimit]
        public IActionResult Register(PatientRegistrationDTO dto)
        {

            
            String message = "";
            Patient patient = PatientRegistrationAdapter.PatientRegistrationDTOtoPatient(dto);
            Patient registeredPatient = registrationController.Register(patient);
            if(registeredPatient == null)
            {
                message = "Registration failed";
            }
            else
            {
                message = "Registration success";
            }

            return Ok(message);
        }
    }
}
