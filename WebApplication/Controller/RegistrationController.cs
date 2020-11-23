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
        WebStateController stateController;
        WebCityController cityController;
        WebAddressController addressController;
        public RegistrationController()
        {
            this.registrationController = new WebRegistrationController();
            this.stateController = new WebStateController();
            this.cityController = new WebCityController();
            this.addressController = new WebAddressController();
        }
        [HttpGet("proba")]
        public IActionResult Proba()
        {
            Address address = SaveAddress("Maksima Gorkog 23", 1, 0, 0, 11000);
            if(address == null)
            {
                return BadRequest("Neuspesno");
            }
            return Ok(address.Street);
        }
        [HttpPost("image"), DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        public IActionResult Image()
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

        [HttpPost("patientRegistration")]
        public IActionResult Register(PatientRegistrationDTO dto)
        {
            IActionResult actionResult;
            State stateOfBirth = SaveState(dto.StateOfBirth);
            City cityOfBirth = SaveCity(dto.PostalCodeBirth, dto.CityOfBirth, stateOfBirth.Id);

            State currResidenceState = SaveState(dto.State);
            City currResidenceCity = SaveCity(dto.PostalCode, dto.City, currResidenceState.Id);
            Address currResidenceAddress = SaveAddress(dto.Street, dto.Number, dto.Floor, dto.Apartment, currResidenceCity.Id);

            dto.PlaceOfBirthId = cityOfBirth.Id;
            dto.CurrentResidenceId = currResidenceAddress.Id;



            
            String message = "";
            Patient patient = PatientRegistrationAdapter.PatientRegistrationDTOtoPatient(dto);
            Patient registeredPatient = registrationController.Register(patient);
            if(registeredPatient == null)
            {
                message = "Usernae already exists";
                actionResult = BadRequest(message);
            }
            else
            {
                message = "Registration success";
                actionResult = Ok(message);
            }

            return actionResult;
        }

        private State SaveState(string name)
        {
            State state = BuildSate(name);
            State savedState = stateController.Save(state);
            return savedState;
        }

        private City SaveCity(int id, string name, long stateId)
        {
            City city = BuildCity(id, name, stateId);
            return cityController.Save(city);
        }

        private Address SaveAddress(string street, int number, int floor, int apartment, int cityId)
        {
            Address address = BuildAddress(street, number, floor, apartment, cityId);
            return addressController.Save(address);
        }

        private State BuildSate(string name)
        {
            return new State { Name = name };
        }

        private City BuildCity(int id, string name, long stateId)
        {
            return new City { Id = id, Name = name, StateId = stateId };
        }

        private Address BuildAddress(string street, int number, int floor, int apartment, int cityId)
        {
            return new Address { Street = street, Number = number, Floor = floor, Apartment = apartment, CityId = cityId };
        }
    }
}
