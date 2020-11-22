using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Users.WebApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        WebRegistrationController registrationController;

        public RegistrationController()
        {
            this.registrationController = new WebRegistrationController();
        }
        public IActionResult Register(string id)
        {
            Patient patient = new Patient { Id = "2406978890094", PlaceOfBirthId= 11000, CurrResidenceId=1, InsurancePolicyId="policy1"};
            Patient registeredPatient = registrationController.Register(patient);
            return Ok(registeredPatient);
        }
    }
}
