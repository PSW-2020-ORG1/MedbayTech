using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Backend.Records.Model;
using Backend.Users.WebApiController;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;
using WebApplication.DTO;
using WebApplication.MailService;
using WebApplication.ObjectBuilder;
using WebApplication.TokenService;
using WebApplication.Validators;


namespace WebApplication.Controller
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        WebRegistrationController registrationController;
        PatientRegistrationBuilder registrationBuilder;

        private IWebHostEnvironment _hostEnvironment;


        private readonly IMailService mailService;
        public RegistrationController(IMailService mailService, IWebHostEnvironment environment)
        {
            this.registrationController = new WebRegistrationController();
            this.registrationBuilder = new PatientRegistrationBuilder();
            this.mailService = mailService;
            _hostEnvironment = environment;
        }

        [HttpGet("proba")]
        public IActionResult GetPath()
        {
            string contentRootPath = _hostEnvironment.ContentRootPath;
            string webRootPath = _hostEnvironment.WebRootPath;

            return Ok(contentRootPath);
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
        [Route("activate")]
        public IActionResult Activate(string userId, string token)
        {
            Patient patient = registrationController.ActivateAccount(userId, token);
            if (patient == null) return BadRequest();

            return Ok("Login Page");
        }
        [HttpPost("image"), DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        public IActionResult Image([FromForm] PostImageDTO dto)
        {
            if (dto.File == null)
            {
                string defaultPath = "Resources/Images/Default/default.jpg";
                registrationController.SetImagePath(defaultPath, dto.Id);
                return Ok();
            }
            if (dto.Id.Equals("null")) return BadRequest("null");
            var file = dto.File;
            var folderNameBase = Path.Combine("Resources", "Images");
            var folderName = Path.Combine(folderNameBase, dto.Id);
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

                string pathForDb = GetDomain() + "/" + "Resources/Images/" + dto.Id + "/" + fileName;
                registrationController.SetImagePath(pathForDb, dto.Id);
                return Ok(dto.Id);
            }
           
            return BadRequest();
        }

        [HttpPost("patientRegistration")]
        public IActionResult Register(PatientRegistrationDTO dto)
        {
            try
            {
                ValidateRegistrationInput.Validate(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (registrationController.PatientExists(dto.Id, dto.Username))
                return BadRequest("Patient already exists");

            InsurancePolicy insurancePolicy = registrationBuilder.SavePolicy(dto.PolicyNumber, dto.Company, dto.PolicyStart, dto.PolicyEnd);
            if (insurancePolicy == null)
                return BadRequest("Policy already exists");

            State stateOfBirth = registrationBuilder.SaveState(dto.StateOfBirth);
            City cityOfBirth = registrationBuilder.SaveCity(dto.PostalCodeBirth, dto.CityOfBirth, stateOfBirth.Id);

            State currResidenceState = registrationBuilder.SaveState(dto.State);
            City currResidenceCity = registrationBuilder.SaveCity(dto.PostalCode, dto.City, currResidenceState.Id);
            Address currResidenceAddress = registrationBuilder.SaveAddress(dto.Street, dto.Number, dto.Floor, dto.Apartment, currResidenceCity.Id);

            dto.PolicyNumber = insurancePolicy.Id;
            dto.PlaceOfBirthId = cityOfBirth.Id;
            dto.CurrentResidenceId = currResidenceAddress.Id;

            Patient patient = PatientRegistrationAdapter.PatientRegistrationDTOtoPatient(dto);

            patient.Token = Token.GenerateGuidToken();

            Patient registeredPatient = registrationController.Register(patient);

            if (registeredPatient == null)
                return BadRequest("Patient already exists");

            registrationBuilder.SaveMedicalRecord(registeredPatient.Id, "", dto.BloodType);

            GenerateEmailInfo(patient);

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

        private void GenerateEmailInfo(Patient patient)
        {
            var link = GenerateUrl(patient.Id, patient.Token);
            string email = patient.Email;
            MailRequest mailRequest = new MailRequest { ToEmail = email, Url = link };
            SendMail(mailRequest);
        }












    }
}
