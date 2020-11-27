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
using WebApplication.MailService;
using WebApplication.ObjectBuilder;

namespace WebApplication.Controller
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        WebRegistrationController registrationController;
        PatientRegistrationBuilder registrationBuilder;
        
        private readonly IMailService mailService;
        public RegistrationController(IMailService mailService)
        {
            this.registrationController = new WebRegistrationController();
            this.registrationBuilder = new PatientRegistrationBuilder();
            this.mailService = mailService;
        }

        
        public async void SendMail(MailRequest request)
        {
           
            try
            {
                await mailService.SendMailAsync(request);
                
            }
            catch (Exception ex)
            {
                throw;
            }

        }

       
        [HttpGet("proba")]
        public IActionResult Proba()
        {
            /*Address address = SaveAddress("Maksima Gorkog 23", 1, 0, 0, 11000);
            if(address == null)
            {
                return BadRequest("Neuspesno");
            }
            return Ok(address.Street);*/

            Patient patient = registrationController.GetUserById("2203998890018");
            if(patient == null)
            {
                return BadRequest();
            }
            
            string guid = Guid.NewGuid().ToString();
            var link = GenerateUrl(patient.Id, guid);
            string email = patient.Email;
            MailRequest mailRequest = new MailRequest { ToEmail = email, Url = link };
            SendMail(mailRequest);
            return Ok(link);
        }
        [Route("activate")]
        public IActionResult Activate(string userId, string token)
        {
            Patient patient = registrationController.ActivateAccount(userId, token);
            if (patient == null) return BadRequest();

            return Ok(patient.Token);
        }
        [HttpPost("image"), DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        public IActionResult Image([FromForm] PostImageDTO dto)
        {
            if (dto.Id.Equals("null")) return BadRequest("null");
            var file = dto.File;
            var folderName1 = Path.Combine("Resources", "Images");
            var folderName = Path.Combine(folderName1, dto.Id);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            Directory.CreateDirectory(pathToSave);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                //Patient patient = registrationController.GetUserById(id);
                return Ok(dto.Id);
            }
            return BadRequest();
        }

        [HttpPost("patientRegistration")]
        public IActionResult Register(PatientRegistrationDTO dto)
        {

            if (registrationController.ExistsById(dto.Id)) 
                return BadRequest("Patient already exists");

            State stateOfBirth = registrationBuilder.SaveState(dto.StateOfBirth);
            City cityOfBirth = registrationBuilder.SaveCity(dto.PostalCodeBirth, dto.CityOfBirth, stateOfBirth.Id);

            State currResidenceState = registrationBuilder.SaveState(dto.State);
            City currResidenceCity = registrationBuilder.SaveCity(dto.PostalCode, dto.City, currResidenceState.Id);
            Address currResidenceAddress = registrationBuilder.SaveAddress(dto.Street, dto.Number, dto.Floor, dto.Apartment, currResidenceCity.Id);

            InsurancePolicy insurancePolicy = registrationBuilder.SavePolicy(dto.PolicyNumber, dto.Company, dto.PolicyStart, dto.PolicyEnd);
            if (insurancePolicy == null)
                return BadRequest("Policy already exists");

            dto.PolicyNumber = insurancePolicy.Id;
            dto.PlaceOfBirthId = cityOfBirth.Id;
            dto.CurrentResidenceId = currResidenceAddress.Id;

            Patient patient = PatientRegistrationAdapter.PatientRegistrationDTOtoPatient(dto);
            patient.Token  = Guid.NewGuid().ToString();
            Patient registeredPatient = registrationController.Register(patient);
            
            var link = GenerateUrl(patient.Id, patient.Token);
            string email = patient.Email;
            MailRequest mailRequest = new MailRequest { ToEmail = email, Url = link };
            SendMail(mailRequest);

            return Ok("Please check your mail to confirm registration");
        }

        private string GenerateUrl(string _userId, string _token)
        {
            string url = Url.Action(nameof(Activate), "Registration", new { userId = _userId, token = _token });
            return "http://localhost:8080" + url;
        }

        private string GetDomain()
        {
            return "http://localhost:8080";
        }

        

        

        

        

       

        
    }
}
