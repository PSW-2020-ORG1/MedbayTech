using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Backend.Users.WebApiController;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WebApplication.Adapters;
using WebApplication.DTO;
using WebApplication.MailService;
using WebApplication.ObjectBuilder;
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
            return Ok(address.Street);

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
            return Ok(link);*/
            PatientRegistrationDTO dto = new PatientRegistrationDTO
            {
                Id = "2222222222223",
                Name = "Bojan",
                Surname = "Vujic",
                Email = "bojanvjc@gmail.com",
                Phone = "0645666905",
                Username = "sddsa",
                Password = "bojan123",
                ConfirmPassword = "bojan123",
                Profession = "programmer",
                CityOfBirth = "Sremska Mitrovica",
                PolicyNumber = "dsadsa",
                Company = "Dunav osiguranje d.o.o",
                PostalCodeBirth = 21000,
                State = "Srbija",
                Street = "Milosa Crnjanskog",
                Number = 0,
                Apartment = 0,
                Floor = 0
            };

            string name = "Bojan";
            
            
            return Ok(name);
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

            try
            {
                ValidateRegistrationInput.Validate(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
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
